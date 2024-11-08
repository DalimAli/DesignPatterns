// Usage:
Facade facade = new Facade();
facade.PerformOperations();

public class SubsystemA
{
    public void OperationA() => Console.WriteLine("Subsystem A operation.");
}

public class SubsystemB
{
    public void OperationB() => Console.WriteLine("Subsystem B operation.");
}

public class Facade
{
    private SubsystemA _subsystemA = new SubsystemA();
    private SubsystemB _subsystemB = new SubsystemB();

    public void PerformOperations()
    {
        _subsystemA.OperationA();
        _subsystemB.OperationB();
    }
}
