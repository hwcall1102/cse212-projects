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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // The function will define a fixed array to the size of "length", it will then get the multiples of "number" 
        // appending them to the array until the array is filled. loop where i = 1; i < length; ++i 
        // within loop create variable for multiple, add multiple to results list. Issue with converting
        // double to double[], re worked as results array rather than list to avoid double conversion issue
        // needs to be i< length not <= length to ensure the loop only runs "lenght" amount of times.
        // i needs to start as 0 to index properly.

        // create a new double[] array with the size equal to "length"
        // create a for loop define int i as zero for the starting index, i < "length"; add 1 to i, within the loop reference
        // the new array at index i, equal to "number" multiplied by i+1 return the array


        double[] result = new double[length];
        for (int i = 0; i < length; ++i) 
        {
            result[i] = number * (i + 1);
        }
        return result; // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // set new integer to 0, create for loop that will find which index to start the rotated list at. define i as 0; 
        // loop condition i < size of list - "amount"; add 1 to i each time, within loop add 1 to new integer each time.
        // create a int list to hold new data, equal to "data" get range of new integer as index with count of size minus new int

        int num = 0;
        for (int i = 0; i < (9-amount); i++)
        {
            num++;
        }
        List<int> newStart = data.GetRange(num, 9 - num);

        // create new loop where i is 1, and adds i to a list until it is the length of the new range
        // within loop add i to newStart insert range in "data" with index of 0 newStart
        // 

        for (int i = 1; i <= num; i++)
        {
            newStart.Add(i);
        }

        data.InsertRange(0, newStart);
        data.RemoveRange(9,9);
    }
}
