using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Can I enqueue an item with data and priority, and dequeue highest priority item
    // Expected Result: "inbound" which is the second added to queue but has highest priority should dequeue first
    // Defect(s) Found: none
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("outbound", 2);
        priorityQueue.Enqueue("inbound", 3);
        priorityQueue.Enqueue("email", 1);
        
        var actual = priorityQueue.Dequeue();
        var expected = "inbound";
   
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    // Scenario: Test if dequeue pulls highest queued value if priority is equal, will add "inbound1" and "inbound2" with priority 3
    // Expected Result: "inbound1"
    // Defect(s) Found: none
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("outbound", 2);
        priorityQueue.Enqueue("inbound1", 3);
        priorityQueue.Enqueue("email", 1);
        priorityQueue.Enqueue("inbound2", 3);
        
        var actual = priorityQueue.Dequeue();
        var expected = "inbound1";

        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    // Scenario: Does the program throw an error if dequeued while empty.
    // Expected Result: Error thrown    
    // Defect(s) Found: none
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }

    }

    // Add more test cases as needed below.
}