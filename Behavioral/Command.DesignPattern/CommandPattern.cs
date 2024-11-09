namespace Command.DesignPattern;

public interface ICommand
{
    void Execute();
}

public class Light
{
    public void TurnOn() => Console.WriteLine("The light is on.");
    public void TurnOff() => Console.WriteLine("The light is off.");
}

public class TurnOnCommand : ICommand
{
    private Light _light;

    public TurnOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

public class TurnOffCommand : ICommand
{
    private Light _light;

    public TurnOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}