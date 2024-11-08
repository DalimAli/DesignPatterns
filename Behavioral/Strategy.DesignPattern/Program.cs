// Usage:
using Strategy.DesignPattern;

Context context = new Context(new AddStrategy());
Console.WriteLine(context.ExecuteStrategy(5, 3)); // Output: 8