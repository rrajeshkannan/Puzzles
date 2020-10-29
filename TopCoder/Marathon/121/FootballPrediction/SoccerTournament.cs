using System;
using System.Collections.Generic;

// https://www.topcoder.com/challenges/71581555-b87a-4930-b37e-d78357073479?tab=details

public class SoccerTournament
{
    public string[] findSolution(int N, int W, int D, int X, int[] scored, int[] conceded, int[] points)
    {
        int n = N * (N - 1) / 2;
        string[] results = new string[n];
        for (int i = 0; i < n; i++) results[i] = "1 1";
        return results;
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int W = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());
        int X = int.Parse(Console.ReadLine());

        int[] scored = new int[N];
        int[] conceded = new int[N];
        int[] points = new int[N];

        for (int i = 0; i < N; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            scored[i] = int.Parse(temp[0]);
            conceded[i] = int.Parse(temp[1]);
            points[i] = int.Parse(temp[2]);
        }

        SoccerTournament prog = new SoccerTournament();
        string[] ret = prog.findSolution(N, W, D, X, scored, conceded, points);

        Console.WriteLine(ret.Length);
        for (int i = 0; i < ret.Length; i++)
            Console.WriteLine(ret[i]);
    }
}