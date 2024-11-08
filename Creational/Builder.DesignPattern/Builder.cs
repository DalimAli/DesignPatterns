namespace Builder.DesignPattern;

public class Car
{
    public string Engine { get; set; }
    public string Tires { get; set; }
    public string Seats { get; set; }

    public override string ToString() => $"Engine: {Engine}, Tires: {Tires}, Seats: {Seats}";
}

public class CarBuilder
{
    private Car car = new Car();

    public CarBuilder SetEngine(string engine)
    {
        car.Engine = engine;
        return this;
    }

    public CarBuilder SetTires(string tires)
    {
        car.Tires = tires;
        return this;
    }

    public CarBuilder SetSeats(string seats)
    {
        car.Seats = seats;
        return this;
    }

    public Car Build()
    {
        return car;
    }
}
