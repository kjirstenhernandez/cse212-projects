public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new int [select.Length];
        int index1 = 0; int index2 = 0; int index3 = 0;
        foreach(int number in select){
            if (number == 1) {
                int check = list1[number];
                result[index3] = list1[index1];
                index1++; 
                index3++;
            }
            else{
                result[index3] = list2[index2];
                index2++;
                index3++;
            }
        }
        return result;
    }
}