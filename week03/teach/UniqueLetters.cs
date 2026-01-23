using System;
using System.Collections.Generic;

public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters are unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = ""; // Expect True because it's an empty string
        Console.WriteLine(AreUniqueLetters(test3));
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        var charSet = new HashSet<char>();

        foreach (var chr in text) {
            if (!charSet.Add(chr)) {
                return false; // Found a duplicate
            }
        }

        return true; // All characters are unique
    }
}