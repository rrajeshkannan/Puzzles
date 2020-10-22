using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FootballMatches
{
    class Program
    {
        public static void Main()
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            TextWriter textWriter = new StreamWriter(Console.OpenStandardOutput());

            int year = Convert.ToInt32(Console.ReadLine().Trim());

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<IFootballMatchesService, FootballMatchesService>();
                })
                .UseConsoleLifetime();
            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    Stopwatch watch = Stopwatch.StartNew();

                    var footballMatchesService = services.GetRequiredService<IFootballMatchesService>();
                    var result = await footballMatchesService.GetNumDraws(year);

                    watch.Stop();

                    textWriter.WriteLine(result);
                    textWriter.WriteLine("Time: {0}", watch.ElapsedMilliseconds);

                    textWriter.Flush();
                    textWriter.Close();

                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred." + ex.ToString());

                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred.");
                }
            }
        }
    }
}

public class PagedMatches
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public IEnumerable<Match> data { get; set; }
}

public class Match
{
    public string competition { get; set; }
    public int year { get; set; }
    public string round { get; set; }
    public string team1 { get; set; }
    public string team2 { get; set; }
    public string team1goals { get; set; }
    public string team2goals { get; set; }
}

public interface IFootballMatchesService
{
    Task<int> GetNumDraws(int year);
}

public class FootballMatchesService : IFootballMatchesService
{
    private readonly IHttpClientFactory _clientFactory;

    public FootballMatchesService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<int> GetNumDraws(int year)
    {
        var matchesForYear = GetMatchesAsync(year).Result;

        if (matchesForYear.total_pages <= 0)
        {
            return 0;
        }

        var tasks = Enumerable.Range(1, matchesForYear.total_pages)
            .Select(async page => await GetNumDrawsAsync(year, page));

        return (await Task.WhenAll(tasks))
            .Sum();
    }

    #region Private Matches

    private readonly String baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";

    private async Task<PagedMatches> GetMatchesAsync(int year)
    {
        // https://jsonmock.hackerrank.com/api/football_matches?year=2011
        String path = String.Format("{0}?year={1}", baseUrl, year);

        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseContentRead);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<PagedMatches>();
        }

        return null;
    }

    private async Task<PagedMatches> GetMatchesAsync(int year, int page)
    {
        // https://jsonmock.hackerrank.com/api/football_matches?year=2011&page=1
        String path = String.Format("{0}?year={1}&page={2}", baseUrl, year, page);

        var client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseContentRead);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<PagedMatches>();
        }

        return null;
    }

    private async Task<int> GetNumDrawsAsync(int year, int page)
    {
        return await GetMatchesAsync(year, page)
            .ContinueWith(pagedMatches => pagedMatches.Result.data.Count(match => match.team1goals == match.team2goals));
    }

    #endregion
}