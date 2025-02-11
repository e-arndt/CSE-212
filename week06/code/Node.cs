public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // If the Insert value equals a value in Data, it's not unique
        // take no futher and simply return
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // If the current value equals a value in Data, then Data contains that value
        // return a bool value of True
        if (value == Data)
        {
            return true;
        }

        else if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }

        else
        {
            return Right != null && Right.Contains(value);
        }
    }


    public int GetHeight()
    {
        // An integer variable is set (leftHeight / rightHeight)
        // A check of each(left / right) subtree is set to check for null of the end(leaf)
        // If not null(True) condition 1 is executed, ex. left.GetHeight()
        // If null is found(False) condition 2 is executed(:0) the variable is set to zero(0)
        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        int rightHeight = (Right != null) ? Right.GetHeight() : 0;

        // Math.Max compares the values stored in the variables and returns the higher value
        // One(1) is added to the higher value to account for inclusion of the current node
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}