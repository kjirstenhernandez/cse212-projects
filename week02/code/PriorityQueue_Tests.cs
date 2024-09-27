using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Items with varying priority are all added to the queue, then removed according to FIFO;
    // Expected Result: high 2, high, mid2, mid, low2, low
    // Defect(s) Found: Dequeue returned the value but did not remove it from the queue; index in Dequeue 
    // started at 1 instead of 0; 'if' statement didn't include curly braces for 'then'; dequeue for loop wasn't
    // checking the full list for priority items. 
    public void TestPriorityQueue_1()
    {
        string[] expectedResult = ["high2", "high", "mid2", "mid", "low2", "low"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("low2", 2);
        priorityQueue.Enqueue("mid", 3);
        priorityQueue.Enqueue("mid2", 4);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("high2", 6);
        
        int i = 0;
        int count = priorityQueue.queueCount();
        for(; i < count; i++) {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
    }
    [TestMethod]
    // Scenario: Items with varying priority are added into the queue, 
    //and the most important are completed first; if an item has the same priority as another, FIFO is followed.
    // Expected Result: high2, high1, mid2, mid1, low2, low1
    // Defect(s) Found: duplicate priority amounts were dequeued on what index was called last, 
    //not which was in the queue first. The highpriorityindex would skip over low2 when checking for priority equivalence.
    public void TestPriorityQueue_2()
    {
        string[] expectedResult = ["high2", "high1","mid2", "mid1", "low2", "low1"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low2", 1);
        priorityQueue.Enqueue("high1", 5);
        priorityQueue.Enqueue("mid1", 3);
        priorityQueue.Enqueue("low1", 1);
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
    // Scenario: an attempt to dequeue is made with nothing in teh queue
    // Expected Result: Error would be thrown, or no value would be returned.
    // Defect(s) Found: trying to force an error and ahve assert catch it without relying 
    // solely on returned null values. 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        }


    // Add more test cases as needed below.
} 