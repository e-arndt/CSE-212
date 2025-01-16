using System;
using System.Threading;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        // int size = new CustomerQueueSize();
        Console.WriteLine("Test 1");
        var csTicket = new CustomerService(2);
        Console.WriteLine(csTicket.ToString());
        Console.WriteLine("Test 1");
        csTicket.AddNewCustomer();
        csTicket.ServeCustomer();
        csTicket.ServeCustomer();
        // Defect(s) Found: 

        Console.WriteLine("=================");
        
        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");
        csTicket.AddNewCustomer();
        csTicket.AddNewCustomer();
        csTicket.AddNewCustomer();
        csTicket.ServeCustomer();
        csTicket.ServeCustomer();
        csTicket.ServeCustomer();
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 5
        // Scenario: Does the max size get defaulted to 10 if an invalid value is provided?
        // Expected Result: It should display 10
        Console.WriteLine("Test 5");
        csTicket = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {csTicket}");
        // Defect(s) Found: None
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine();
            Console.WriteLine("Customer Service Queue is EMPTY");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine();
            Console.WriteLine(customer);
        }
        
        
        
    }

    // private int CustomerQueueSize()
    // {
    //     Console.WriteLine();
    //     Console.Write("Set max size of queue ");
    //     var qSize = Console.ReadLine()!.Trim();
    //     int s = int.Parse(qSize);
    //     if (s < 1)
    //     {
    //         Console.WriteLine("Invalid size entered");
    //         Console.WriteLine("Using default size of 10");
    //         s = 10;
    //         Thread.Sleep(2000);
    //         return s;
    //     }
    //     else 
    //     {
    //         Console.WriteLine($"Setting queue size of {qSize}");
    //         Thread.Sleep(2000);
    //         return s;
    //     }
    // }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}