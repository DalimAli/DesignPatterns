
using FactoryMethod.DesignPattern;

VehicleFactory vehicleFactory = new BikeFactory();
var bike = vehicleFactory.CreateVehicle();
bike.Drive();

Console.ReadKey();
