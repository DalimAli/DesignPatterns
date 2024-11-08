namespace Decorator.DesignPattern;

public interface IComponent
{
    string Operation();
}

public class ConcreteComponent : IComponent
{
    public string Operation()
    {
        return "Concrete Component";
    }
}

public class Decorator : IComponent
{
    protected IComponent component;
    public Decorator(IComponent component)
    {
        this.component = component;
    }
    public virtual string Operation()
    {
        return component.Operation();
    }
}

public class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }

    public override string Operation() => $"Decorated({base.Operation()})";
}
