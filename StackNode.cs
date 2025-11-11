namespace DSA_Stack;

public class StackNode<T>
{
    public T Value { get; }
    public StackNode<T> Next { get; set; }

    public StackNode(T value) => Value = value;
}
