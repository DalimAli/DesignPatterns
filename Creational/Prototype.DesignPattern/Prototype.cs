namespace Prototype.DesignPattern;

public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class ConcretePrototype : Prototype
{
    public int Id { get; set; }
    public string Data { get; set; }
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"Id {Id}, Data {Data}";
    }
}
