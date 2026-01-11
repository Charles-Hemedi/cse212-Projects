public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // --- PLAN ---
        // 1. Initialize a new array of doubles with the size specified by the 'length' parameter.
        // 2. Create a loop that runs 'length' number of times (from index 0 to length - 1).
        // 3. In each iteration, calculate the multiple by multiplying 'number' by (index + 1).
        //    (e.g., if index is 0, multiple is number * 1; if index is 1, multiple is number * 2).
        // 4. Store that calculated value into the current index of the array.
        // 5. After the loop finishes, return the completed array.

        // Implementation:
        double[] results = new double[length];

        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // --- PLAN ---
        // 1. Identify the split point. Since we are moving the "end" of the list to the "front",
        //    the number of elements to move is 'amount'.
        // 2. The starting index of the section to be moved is (data.Count - amount).
        // 3. Use GetRange to extract the elements from the split point to the end of the list 
        //    and store them in a temporary list.
        // 4. Use RemoveRange to delete those same elements from their original position at the end of the list.
        // 5. Use InsertRange to place the temporary list back into the original list at index 0.

        // Implementation:
        if (data.Count == 0 || amount == 0 || amount == data.Count) return;

        // Get the items from the end that need to move to the front
        int startingIndex = data.Count - amount;
        List<int> movedPart = data.GetRange(startingIndex, amount);

        // Remove them from the end
        data.RemoveRange(startingIndex, amount);

        // Put them at the beginning
        data.InsertRange(0, movedPart);
    }
}
