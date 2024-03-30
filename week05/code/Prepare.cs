// Consider using a recursive function to sum all of the numbers from 1 to n.
// What is the "smaller version" of this problem that could be used to solve the case of adding some number such as n?
// What is the base case?


public static class RecursiveSum {
    public static void Run() {
        Console.WriteLine(Sum(1)); // 1
        Console.WriteLine(Sum(5)); // 15
        Console.WriteLine(Sum(10)); // 55
    }
    public static int Sum(int n) {
        if (n < 0) {
            return 0;
        }
        else if (n == 1) {
            return 1;
        } else {
            return n + Sum(n - 1);
            // 5 + 4 + 3 + 2 + 1 (returned from above)
            // order goes 1 + 2 + 3 + 4 + 5 so if we need order of operation 
        }
    }
}


