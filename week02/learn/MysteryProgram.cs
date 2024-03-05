using System;
using System.Collections.Generic;

class D
{
    static void Main()
    {
        int[] d = R(5);
        Array.Sort(d); // sort in order assending our random array of 5 random numbers
        Console.WriteLine("Values: " + string.Join(", ", d));
        int s = C(d); // pass our ordered array to C, if no duplicate random numbers generated s=0. otherwise s returns a higher number based on number of duplicates 
        Console.WriteLine("Total: " + s); // if d = [2, 2, 3, 3, 3], s =10+20
    }

    static int[] R(int n)
    {
        Random r = new Random();
        int[] d = new int[n]; // new array with a capacity of 5
        for (int i = 0; i < n; i++) // add random numbers between 1 and 7 at each index 0-4
        {
            d[i] = r.Next(1, 7);
        }
        return d;
    }

    static int C(int[] d)
    {
        int s = 0;
        Dictionary<int, int> c = new Dictionary<int, int>();
        foreach (int x in d) // turn our array into a dic. 
        {
            if (c.ContainsKey(x)) // check if our array number exists as a key already. 
            {
                c[x]++; // if key exists, increase the value at the key by 1
            }
            else
            {
                c[x] = 1; // if key does not exist, associate a value of 1 at the key
            }
        }
        foreach (int v in c.Values) // run through each value in the dic. 
        {
            switch (v) // if the value (quantity of random numbers generated being the same) is 2, 3, 4, or 5 we incrase s
            {
                case 2:
                    s += 10;
                    break;
                case 3:
                    s += 20;
                    break;
                case 4:
                    s += 30;
                    break;
                case 5:
                    s += 40;
                    break;
            }
        }
        return s;
    }
}
