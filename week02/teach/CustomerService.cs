/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: create queue size of 0
        // Expected Result: default will set max_size = 10 with size = 0
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Jess, id of 1, has a problem with bluetooth.
        // Expected Result: queue will have 1 customer Jess (1) : bluetooth
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(1);
        cs2.AddNewCustomer();
        Console.WriteLine(cs2);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: create 2 customers with a queue size of 1. 
        // Expected Result: error message displayed because too many customers for queue size.
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(1);
        for (int i = 0; i < 2; i++)
        {
            cs3.AddNewCustomer();
        }
        Console.WriteLine(cs3);

        // Defect(s) Found: que size of 2 when max_size is 1. No error message

        Console.WriteLine("=================");

        // Test 4
        // Scenario: add 2 customers to queue and then serve them in the correct order.
        // Expected Result: customer 1 should be served first followed by customer 2.
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(3);
        for (int i = 0; i < 2; i++)
        {
            cs4.AddNewCustomer();
        }
        for (int i = 0; i < 2; i++)
        {
            cs4.ServeCustomer();
        }

        // Defect(s) Found: ServeCustomer error: 'Index was out of range. Must be non-negative and less than the size of the collection.'

        Console.WriteLine("=================");

        // Test 5
        // Scenario: create 1 customer, attempt to serve 2 customers in queue.
        // Expected Result: error message displayed due to running ServeCustomer with an empty queue.
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(3);
        for (int i = 0; i < 1; i++)
        {
            cs5.AddNewCustomer();
        }
        for (int i = 0; i < 2; i++)
        {
            cs5.ServeCustomer();
        }

        // Defect(s) Found: 

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        else
        {
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
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count > 0)
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("Error: No one in Queue");
            return;
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}