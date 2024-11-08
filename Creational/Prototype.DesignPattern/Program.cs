using Prototype.DesignPattern;

ConcretePrototype concretePrototype = new ConcretePrototype()
{
    Id = 1,
    Data = "Proto"
};

ConcretePrototype clone = (ConcretePrototype) concretePrototype.Clone();
clone.Id = 2;

Console.WriteLine(concretePrototype);
Console.WriteLine(clone);
