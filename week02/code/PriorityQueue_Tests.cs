using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Items with varying priority are added into the queue, 
    //and the most important are completed first.
    // Expected Result: high2, high1, mid2, mid1, low2, low1
    // Defect(s) Found: Dequeue returned the value but did not remove it from the queue; index in Dequeue 
    // started at 1 instead of 0; 'if' statement didn't include curly braces for 'then'; dequeue for loop wasn't
    // checking the full list for priority items. 
    public void TestPriorityQueue_1()
    {
        string[] expectedResult = ["high2", "high1","mid2", "mid1", "low2", "low1"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low1", 1);
        priorityQueue.Enqueue("high1", 5);
        priorityQueue.Enqueue("mid1", 3);
        priorityQueue.Enqueue("low2", 2);
        priorityQueue.Enqueue("high2", 6);
        priorityQueue.Enqueue("mid2", 4);
        
        int i = 0;
        int count = priorityQueue.queueCount();
        for(; i < count; i++) {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
        
    
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
} 