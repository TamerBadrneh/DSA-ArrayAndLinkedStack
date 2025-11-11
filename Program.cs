using System.Text;

namespace DSA_Stack;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Valid Parenthesis Problem:");
        Console.WriteLine($"Test Case 1: [{{()}}]");
        Console.WriteLine("Expected: True.");
        Console.WriteLine($"Actual: {ValidateParenthesis("[{()}]")}.");

        Console.WriteLine($"Test Case 2: [{{(}}]");
        Console.WriteLine("Expected: False.");
        Console.WriteLine($"Actual: {ValidateParenthesis("[{(}]")}.");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Reverse a string using stack: ");
        Console.WriteLine("Test Case 1: \"Tamer\"");
        Console.WriteLine("Expected: \"remaT\"");
        Console.WriteLine($"Actual: \"{Reverse("Tamer")}\"");

        Console.WriteLine();
        Console.WriteLine();

    }
    private static bool IsOpenParenthesis(char character)
    {
        return character == '(' || character == '{' || character == '[';
    }

    public static bool ValidateParenthesis(string expression)
    {
        LinkedStack<char> stack = new LinkedStack<char>();

        foreach(char character in expression)
            if (IsOpenParenthesis(character))
                stack.Push(character);
            else if (!IsOpenParenthesis(character) && (stack.Top() == '{' && character == '}'))
                stack.Pop();
            else if (!IsOpenParenthesis(character) && (stack.Top() == '[' && character == ']'))
                stack.Pop();
            else if (!IsOpenParenthesis(character) && (stack.Top() == '(' && character == ')'))
                stack.Pop();
            else
                return false;

        return stack.IsEmpty();
    }

    public static string Reverse(string text)
    {
        ArrayStack<char> stack = new(text.Length);
        foreach(char character in text)
            stack.Push(character);
        StringBuilder result = new();
        while(!stack.IsEmpty())
            result.Append(stack.Pop());
        return result.ToString();
    }
}
