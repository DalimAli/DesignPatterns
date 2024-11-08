namespace Adapter.DesignPattern;

public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest in Adaptee.");
    }
}

public class Adapter : ITarget
{
    private Adaptee _adaptee = new Adaptee();

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}