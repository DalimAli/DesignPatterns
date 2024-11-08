namespace Strategy.DesignPattern;

public interface IStrategy
{
    int DoOperation(int num1, int num2);
}

public class AddStrategy : IStrategy
{
    public int DoOperation(int num1, int num2) => num1 + num2;
}

public class MultiplyStrategy : IStrategy
{
    public int DoOperation(int num1, int num2) => num1 * num2;
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public int ExecuteStrategy(int num1, int num2)
    {
        return _strategy.DoOperation(num1, num2);
    }
}
