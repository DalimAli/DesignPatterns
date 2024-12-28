//The Client will use the Facade Interface instead of the Subsystems
using FacadePattern;

Order order = new Order();
order.PlaceOrder();
Console.Read();