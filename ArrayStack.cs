using System.Text;

namespace DSA_Stack;

public class ArrayStack<T>
{
    private T[] stack;
    private int stackPointer;

    
    public ArrayStack(int size = 10) => stack = Create(size);




    private static T[] Create(int size = 10)
    {
        if (size < 1)
            throw new InvalidDataException($"Can't create a stack of {size} elements.");
        return new T[size];
    }

    private static T[] ExtendAndCopy(T[] oldStack)
    {
        T[] newStack = Create(oldStack.Length + (oldStack.Length / 2));
        for (int index = 0; index < oldStack.Length; index++)
            newStack[index] = oldStack[index];
        return newStack;
    }

    
    
    public void Push(T item)
    {
        if(IsFull())
            stack = ExtendAndCopy(stack);
        stack[stackPointer] = item;
        stackPointer++;
    }

    public T Top() => IsEmpty() ? throw new InvalidOperationException($"Can't read the top element of an empty stack.") : stack[stackPointer - 1];

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException($"Can't pop the top element of an empty stack.");

        T top = Top();
        stackPointer--;
        return top;
    }

    public bool IsEmpty() => stackPointer == 0;

    public bool IsFull() => stackPointer == stack.Length;

    public int Count() => stackPointer;

    public void Clear() => stackPointer = 0;

    public override string ToString()
    {
        if (IsEmpty())
            return string.Empty;

        StringBuilder builder = new StringBuilder("Stack Elements: \n");
        for (int index = stackPointer - 1; index >= 0; index--)
            builder.AppendLine($"[{stack[index]}]");
        return builder.ToString();
    }
}
