public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public bool Insert(int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return true;
        }

        return InsertRecursive(root, value);
    }

    private bool InsertRecursive(Node current, int value)
    {
        if (value == current.Value)
        {
            // El valor ya está en el árbol, no se inserta
            return false;
        }

        if (value < current.Value)
        {
            if (current.Left == null)
            {
                current.Left = new Node(value);
                return true;
            }
            else
            {
                return InsertRecursive(current.Left, value);
            }
        }
        else
        {
            if (current.Right == null)
            {
                current.Right = new Node(value);
                return true;
            }
            else
            {
                return InsertRecursive(current.Right, value);
            }
        }
    }
}
