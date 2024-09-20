using System.Security.Cryptography.X509Certificates;
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
        // We need to create a list with a capacity equal to the specified number of multiples, then make a variable to multiply against our fixed number;
        // We'll use a for-loop to multiply, add the result to the array, and then increase the variable value by 1 each time; that way the variable can
        // double as our "multiple counter" so that the loop stops after we reach our desired amount of multiples in the array. 

        double[] multiples = new double[length]; //creating an empty array with a capacity of the requested number of multiples
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

        // Visually, rotating the list to the right by the specified amount, the last X elements of the list (x=amount) move to the front, and the remaining elements shift to the right.
        // We can achieve this by obtaining the data.Count and subtracting 'amount', giving us the amount of beginning elements that need to shift to the end of the array.
        // Then we just have to remove the indexes of those elements, and our 'rotation' will be finished.
        
        int rotation = data.Count - amount; // establishing how many elements need to move from the front to the back of the array
        for(int i = 0; i<rotation; i++) { // "i" representing the index of the element we're moving to the back, starting at the first and going until we reach the numbers that will be the new start of our array, and adding one to the "index" each time;
            data.Add(data[i]);   //add the element with the current index to the end of the array.
        }
        data.RemoveRange(0, rotation); // removing the elements that we're swapping from the front to the back of the array. 
    }
}
