public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
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
    private static List<int> FindDivisors(int number) {
        List<int> results = new();
        
    for (int i = 1; i * i <= number; i++) {
        if (number % i == 0) {
            // i is a divisor
            if (i != number) {
                results.Add(i);
            }

            int pair = number / i;
            // add the paired divisor if it's different
            // and not the number itself
            if (pair != i && pair != number) {
                results.Add(pair);
            }
        }
    }

    results.Sort();
    return results;
    }
}