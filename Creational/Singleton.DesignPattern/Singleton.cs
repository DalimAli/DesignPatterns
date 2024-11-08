using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.DesignPattern
{
    public sealed class Singleton
    {
        public static Singleton _instance;
        public static int count = 0;

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null) { 
                    count++;
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        public void DoSomething()
        {
            Console.WriteLine($"Singleton instance called. and count is {count}");
        }
    }
}
