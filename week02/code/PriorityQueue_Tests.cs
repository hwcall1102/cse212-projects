using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Can I enqueue an item with data and priority 
    // Expected Result: items should be queued in order added
    // Defect(s) Found: Need to add if empty code
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var actual = priorityQueue.Dequeue();
        
   
        Assert.ThrowsException<InvalidOperationException>(() => actual);
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