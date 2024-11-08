// Usage:
using Decorator.DesignPattern;

IComponent component = new ConcreteDecorator(new ConcreteComponent());
Console.WriteLine(component.Operation()); 