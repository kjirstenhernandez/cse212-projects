using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

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

        double[] multiples = new double[length]; //creating an empty array with a length of the requested number of 
        for (int i = 1; i<=length; i++) { // we're going to start with a multiple of 1; by adding 1 to i each time and comparing it to the requested number of multiples we'll restrict the number of results to that given number.
            double multiple = number * i; // formula to get multiples (Multiple = Number*integer)
            multiples[(i-1)] = multiple; // we'll use our i to establish the index of where it needs to be placed in the array, minus 1 because indexes start at 0. 
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    /// 

    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // we need a formula that will take a specified number and rotate a given list by that amount
        // we'll need to use the .count() method to get the number 
        
        int rotation = data.Count - amount;
        for(int i = 0; i<rotation; i++) {
            data.Add(data[i]);   
        }
        for (int i = 0; i<rotation; i++) {
            data.RemoveAt(0);
        }
    }
}
