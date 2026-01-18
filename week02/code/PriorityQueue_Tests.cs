using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them. Higher priority should be dequeued first.
    // Expected Result: Items should be dequeued in order of highest priority first. When priorities are equal, FIFO order should be maintained.
    // Defect(s) Found: Dequeue() does not remove items from the queue. Loop condition is wrong (index < _queue.Count - 1 instead of index < _queue.Count).
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority. Should follow FIFO order (first in, first out).
    // Expected Result: When multiple items have the same highest priority, the one that was enqueued first should be dequeued first.
    // Defect(s) Found: Dequeue() does not remove items from the queue. Comparison uses >= instead of >, breaking FIFO order for same priority items.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 2);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, some with same priority. Highest priority first, then FIFO for same priority.
    // Expected Result: Highest priority items dequeued first, and among items with same priority, FIFO order is maintained.
    // Defect(s) Found: Dequeue() does not remove items from the queue. Comparison uses >= instead of >, breaking FIFO order for same priority items.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 2);
        
        // B and D both have priority 3, but B was enqueued first, so B should come first
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        // C and E both have priority 2, but C was enqueued first, so C should come first
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty."
    // Defect(s) Found: None - test passes. Exception handling is correct.
    public void TestPriorityQueue_EmptyQueue()
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

    [TestMethod]
    // Scenario: Enqueue items to the back of the queue (FIFO behavior for enqueue).
    // Expected Result: Items should be added to the back of the queue, maintaining order when priorities are the same.
    // Defect(s) Found: Dequeue() does not remove items from the queue. Comparison uses >= instead of >, breaking FIFO order for same priority items.
    public void TestPriorityQueue_EnqueueToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);
        
        // All have same priority, so should dequeue in FIFO order
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test with negative priorities and zero priority.
    // Expected Result: Higher numbers have higher priority, so negative numbers have lower priority than zero.
    // Defect(s) Found: Dequeue() does not remove items from the queue. Loop condition is wrong (index < _queue.Count - 1 instead of index < _queue.Count), missing the last item.
    public void TestPriorityQueue_NegativeAndZeroPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Negative", -1);
        priorityQueue.Enqueue("Zero", 0);
        priorityQueue.Enqueue("Positive", 1);
        
        Assert.AreEqual("Positive", priorityQueue.Dequeue());
        Assert.AreEqual("Zero", priorityQueue.Dequeue());
        Assert.AreEqual("Negative", priorityQueue.Dequeue());
    }
}