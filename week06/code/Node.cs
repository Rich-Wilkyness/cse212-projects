using System.Diagnostics.Metrics;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else if (value == Data) {
            Console.WriteLine("Sorry, you cannot add duplicates to this tree.");
        }
    }

    public bool Contains(int value) {
        // TODO Start Problem 2
        // Console.WriteLine($"Value: {value}, Data: {Data}");
        if (value < Data) {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else if (value > Data) {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        else if (value == Data) {
            return true;
        } 
        else {
            return false;
        }
    }

        // counter starts at 1 because we have already determined in our GetHeight call that there is a tree
    public int GetHeight(int counter = 1) {
        // TODO Start Problem 4
        // height is synonymous with depth of the tree
        // use a counter to determine how deep we go and compare to previous depths
        // keep the deeper of the depths

        if (Left == null && Right == null) {
            return counter;
        }
        else { // have reached the top / bottom of a subtree
            // if left subtree is determined not to be null, recursive
            // else left subtree = counter
            // same is done on the right and then the two are compared
            int leftHeight = Left != null ? Left.GetHeight(counter + 1) : counter;
            int rightHeight = Right != null ? Right.GetHeight(counter + 1) : counter;
            return Math.Max(leftHeight, rightHeight);
        }        
    }
}  