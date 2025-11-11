namespace DSA_Stack;

public class Program
{
    public static void Main(string[] args)
    {

        try
        {
            Console.WriteLine("=== Testing LinkedStack<int> ===");
            LinkedStack<int> intStack = new LinkedStack<int>();

            Console.WriteLine("Pushing elements:");
            for (int i = 1; i <= 10; i++)
            {
                intStack.Push(i);
                Console.WriteLine($"Pushed: {i}, Top: {intStack.Top()}");
            }

            
            Console.WriteLine("\n============");
            Console.Write(intStack);
            Console.WriteLine("============");


            Console.WriteLine("\nPopping elements:");
            while (!intStack.IsEmpty())
                Console.WriteLine($"Popped: {intStack.Pop()}");

            Console.WriteLine("\nStack empty? " + intStack.IsEmpty());

            // Uncomment to test popping from empty stack
            // intStack.Pop();

            Console.WriteLine("\n=== Testing LinkedStack<string> ===");
            LinkedStack<string> stringStack = new LinkedStack<string>();
            stringStack.Push("First");
            stringStack.Push("Second");
            stringStack.Push("Third"); // triggers resize

            Console.WriteLine($"Top element: {stringStack.Top()}");
            Console.WriteLine($"Popped element: {stringStack.Pop()}");
            Console.WriteLine($"Now top is: {stringStack.Top()}");

            Console.WriteLine("\n=== Testing invalid stack creation ===");
            try
            {
                var badStack = new LinkedStack<double>();
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine("Caught expected exception: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
