using Builder.DesignPattern;

Car car = new CarBuilder()
        .SetTires("Michelin")
        .SetSeats("Leather")
        .SetEngine("Engine")
        .Build();

Console.WriteLine(car);
Console.ReadKey();
