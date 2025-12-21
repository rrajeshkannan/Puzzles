Console.WriteLine(LastInteger(10));


long LastInteger(long n)
{
    var first = n / 2;
    var reminder = n % 2;

    return first + reminder + 1;
}