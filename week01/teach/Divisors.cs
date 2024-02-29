using System.Net.WebSockets;

public static class Divisors
{
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run()
    {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number)
    {
        List<int> results = new List<int>();
        List<int> inverseResults = new List<int>();
        // Todo problem 1
        for (int i = 1; i <= number / 2; i++)
        {
            var divisible = number / i;
            bool isWholeNumber = divisible == Math.Floor((decimal)divisible) && divisible == Math.Ceiling((decimal)divisible);
            if (isWholeNumber)
            {
                results.Add(i);
                inverseResults.Add(divisible);
            }
        }
        for (int j = inverseResults.Count; j > 0; j--)
        {
            results.Add(inverseResults[j]);
        }
        return results;
    }
}