using UtilsLibrary;

var lines = Utils.ReadLinesFromCsvFile();

foreach (var line in lines)
{
    Console.WriteLine(ReverseWords(line));
}

string ReverseWords(string s)
{
    var words = s.Split(' ');
    var firstWord = words[0];
    var vowelCount = GetVowelChars(firstWord).Count();

    var output = new List<string> { firstWord };

    for (int i = 1; i < words.Length; i++)
    {
        var word = words[i];

        if (MatchVowelCount(word, vowelCount, out var reversedWord))
        {
            output.Add(reversedWord);
        }
        else
        {
            output.Add(word);
        }
    }

    return string.Join(' ', output);
}

IEnumerable<char> GetVowelChars(string word)
{
    foreach (char c in word)
    {
        switch (c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                yield return c;
                break;
        }
    }
}

bool MatchVowelCount(string word, int targetVowelCount, out String reversedWord)
{
    var vowelCount = 0;
    var charCount = 0;
    Stack<char> reversed = new Stack<char>();

    foreach (char c in word)
    {
        switch (c)
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                vowelCount++;
                break;
        }

        charCount++;
        reversed.Push(c);

        if (vowelCount > targetVowelCount)
        {
            reversedWord = String.Empty;
            return false;
        }
    }

    if (vowelCount == targetVowelCount)
    {
        var reversedWordChars = new char[charCount];
        var i = 0;

        while (i < charCount)
        {
            reversedWordChars[i++] = reversed.Pop();
        }

        reversedWord = new string(reversedWordChars);
        return true;
    }
    else
    {
        reversedWord = String.Empty;
        return false;
    }
}