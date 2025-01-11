using System.Diagnostics;


public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    // Define a public, static method called MultiplesOf that will return a type of double and is expecting two paramters.
    // First parameter is called number and is a double(floating point number), second is called length 
    // and is an integer number.
    public static double[] MultiplesOf(double number, int length)
    // Create an array called results that stores doubles(floating point numbers such as 17.25).
    // Declare the length of the new array from the length parameter that is passed into the MultiplesOf method.
    {   double[] results = new double[length];
    // A For loop that processes the multiplying of the number passed in through the number parameter a certain number 
    // of times. That certain number of times is specified by the length parameter. So the variable i in the For loop is 
    // initially set to zero(0), checks i to see if i is less than the number specified in the length parameter and 
    // increments i up by adding 1 to i.
    // The block of the loop takes the number parameter passed in and multiplies it by i + 1.
    // Since i starts at zero(0), we don't want to multiply by 0. The multiplying will start a 0+1 or just 1.
    // So if the number parameter is 5 and this is the first execution of the For loop, the math would be 5 * (0+1)
    // or 5*1 which equals 5, second loop is 5*2 and so on until the loop reaches the length parameter value and stops.
    // Also part of this process, the result of the multiplication is stored in the results array starting at index i
    // which is set to zero, this is why i starts at zero(0) and we add 1 when multiplying.
        for (int i = 0; i < length; ++i) 
        {
            results[i] = number * (i + 1);
            
        }

    // The contents of the results array are returned to the caller of the MultiplesOf method.
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 
    // Define a public, static method called RotateListRight that returns nothing(void) and is expecting two paramters.
    // First parameter is a list of integers called data, the second is called amount and is an integer number.
    public static void RotateListRight(List<int> data, int amount)
    {
    // An integer varible called shiftCount is set to zero(0) which tracks how many places we will need to shift back.
        int shiftCount = 0;
    // For loop that starts i at zero(0), checks that i is less than 9(size of the list of numbers) - the amount parameter.
    // 1 is added to i, shiftCount also has 1 added to it. This finds the index of the number in the data list where we
    // want to start / sort the new list.
        for (int i = 0; i < (9-amount); i++)
        {
            shiftCount++;
        }

    // Define a list of integers called newSort, read from the original list called data and get a certain range
    // of numbers from that list using GetRange. The first value is the index of the first number we want, specified
    // by the number stored in shiftCount. Take all the numbers from index till count.
    // ex. if data is 1 2 3 4 5 6 7 8 9 and amount is 5, we want the new list to be 5 6 7 8 9 1 2 3 4
    // We need an index of 4 to get to the number 5 in the list. The For loop will count shiftCount up to 4, shown as
    // 9 - amount(5) in the For loop which would be 4. So index of 4 which gets us to 5 and we need the next 5 numbers.
    // 9 - shiftCount(4) which is 5. So we start at 5 count 5 and get 5 6 7 8 9
        List<int> newSort = data.GetRange(index:shiftCount, count: (9 - shiftCount));

        for (int i = 1; i <= shiftCount; i++)
        {
            newSort.Add(i);
        }

    // Using InsertRange, add the new sorted list to the original list called data, starting at index 0
        data.InsertRange(index:0, newSort);

    // Using RemoveRange, remove from the original list all of the original numbers and leave just the new 
    // sorted numbers by starting at index 9 which is now the first number of the original list and remove 
    // all 9 of the original numbers.
        data.RemoveRange(index:9, count:9);

    }
}
