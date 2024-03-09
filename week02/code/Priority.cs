using System.Xml.XPath;

public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        // var priorityQueue = new PriorityQueue();
        // Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Add 3 items to the queue with the following priorities: A (1), B (2), C (3).
        // Expected Result: the order of the queue should be A, B, C (this is not the order of the dequeue).
        Console.WriteLine("Test 1");
        var pQ1 = new PriorityQueue();
        pQ1.Enqueue("A", 1);
        pQ1.Enqueue("B", 2);
        pQ1.Enqueue("C", 3);
        Console.WriteLine(pQ1);

        // Defect(s) Found: works as expected.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Add 4 items to the queue with the following priorities: A (1), B (2), C (3), D(3) then dequeue 4 times.
        // Expected Result: the order of the dequeue should be C, D, B, A (C should be dequeued first, having both the highest priority and the closest to the front of the queue).
        Console.WriteLine("Test 2");
        var pQ2 = new PriorityQueue();

        pQ2.Enqueue("A", 1);
        pQ2.Enqueue("B", 2);
        pQ2.Enqueue("C", 3);
        pQ2.Enqueue("D", 3);
        for (int i = 0; i < 4; i++) {
            var Result = pQ2.Dequeue();
            Console.WriteLine(Result);
        }

        // Defect(s) Found: C is not getting removed from the Queue. Had to remove a "-1" from the for loop count (we were not running through all of the results to get the highest priority). Also removed an "=" sign from the if priority higher than or equal to the current highest priority (this means the first item with the highest priority will be removed, not the last one). Also completed the if statement with an if else and else statment to cover all potential cases.

        Console.WriteLine("---------");
        // Test 3
        // Scenario: Dequeue an empty queue.
        // Expected Result: the queue should be empty and the dequeue should return an error message.

        Console.WriteLine("Test 3");
        var pQ3 = new PriorityQueue();
        pQ3.Dequeue();

        // Defect(s) Found: works as expected.


        // Add more Test Cases As Needed Below
    }
}