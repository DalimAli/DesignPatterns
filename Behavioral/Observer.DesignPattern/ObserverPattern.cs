namespace Observer.DesignPattern;

public interface IObserver
{
    void Update();
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

public class ConcreteObserver : IObserver
{
    public void Update()
    {
        Console.WriteLine("Observer has been notified.");
    }
}
