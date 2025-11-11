using System.Text;

namespace DSA_Stack;

public class LinkedStack<T>
{
    private StackNode<T>? stackPointer { get; set; } = null;
    public int Count { get; private set; } = 0;



    public void Push(T item)
    {
        StackNode<T> newNode = new StackNode<T>(item);
        newNode.Next = stackPointer;
        stackPointer = newNode;
        Count++;
    }

    public T Top() => IsEmpty() ? throw new InvalidOperationException("Can't retrieve the top value of an empty stack.") : stackPointer!.Value;

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Can't pop a value from an empty stack.");

        T value = Top();
        StackNode<T>? temp = stackPointer;
        stackPointer = stackPointer.Next;
        temp.Next = null;
        Count--;

        return value;
    }

    public bool IsEmpty() => stackPointer == null;

    public void Clear()
    {
        while (!IsEmpty())
            Pop();
    }

    public override string ToString()
    {
        if(IsEmpty())
            return string.Empty;

        StringBuilder builder = new StringBuilder("Stack Elements: \n");
        StackNode<T>? iterator = stackPointer;
        
        while(iterator != null)
        {
            builder.AppendLine($"[{iterator.Value}]");
            iterator = iterator.Next;
        }

        return builder.ToString();
    }
}
