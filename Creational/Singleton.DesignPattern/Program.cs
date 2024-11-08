namespace Singleton.DesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.DoSomething();
            Singleton.Instance.DoSomething();

            Console.ReadKey();
        }
    }
}
