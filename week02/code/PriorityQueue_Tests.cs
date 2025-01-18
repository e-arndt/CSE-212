using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add objects to the queue with the following Value / Priority pairs: 
    // Dog (2), Bird (3), Fish (5), Cat (7).
    // Run until all objects have been sorted by priority and queue is empty
    // Expected Result: cat, fish, bird, dog
    // Defect(s) Found: Dequeue method for loop index needed to start at 0, index condition
    // changed to <= instead of just <.
    // Dequeue method was missing code to remove highest priority item from queue.

    public void TestPriorityQueue_Enqueue_Dequeue()
    {
        var dog = new PriorityItem("Dog", 2);
        var bird = new PriorityItem("Bird", 3);
        var fish = new PriorityItem("Fish", 5);
        var cat = new PriorityItem("Cat", 7);

        PriorityItem[] expectedResult = [cat, fish, bird, dog];

        var pets = new PriorityQueue();
        pets.Enqueue(dog.Value, dog.Priority);
        pets.Enqueue(bird.Value, bird.Priority);
        pets.Enqueue(fish.Value, fish.Priority);
        pets.Enqueue(cat.Value, cat.Priority);
        
        for (int i = 0; i < 4; i++)
        {
            var pet = pets.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, pet);
            
        }
        
    }

    [TestMethod]
    // Scenario: Add objects to the queue with the following Value / Priority pairs: 
    // Dog (2), Bird (3), Fish (5), Cat (5) in order to test items of same priority
    // are removed and returned in FIFO order.
    // Expected Result: fish, cat, bird, dog
    // Defect(s) Found: Comparison statement in Dequeue method that tests
    // for the highest priority was setting HighPriorityIndex when equal
    // rather than only when higher.

    public void TestPriorityQueue_Same_Priority()
    {
        var dog = new PriorityItem("Dog", 2);
        var bird = new PriorityItem("Bird", 3);
        var fish = new PriorityItem("Fish", 5);
        var cat = new PriorityItem("Cat", 5);

        PriorityItem[] expectedResult = [fish, cat, bird, dog];

        var pets = new PriorityQueue();
        pets.Enqueue(dog.Value, dog.Priority);
        pets.Enqueue(bird.Value, bird.Priority);
        pets.Enqueue(fish.Value, fish.Priority);
        pets.Enqueue(cat.Value, cat.Priority);
        
        for (int i = 0; i < 4; i++)
        {
            var pet = pets.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, pet);
            
        }
        
    }

    [TestMethod]
    // Scenario: Try to pull or Dequeue from an empty queue
    // Expected Result: An Exception error and message are thrown
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty_Queue()
    {
        var pets = new PriorityQueue();

        try 
        { 
            pets.Dequeue(); 
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
            Assert.Fail( string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message) ); 
        }

    }
    // Add more test cases as needed below.

}