using System;
using System.Text;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Завдання 1. Abstract Factory");
            AbstractFactory.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 2. Builder");
            Builder.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 3. Mediator");
            Mediator.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 4. Decorator");
            Decorator.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 5. Prototype");
            Prototype.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 6. Factory Method");
            FactoryMethod.Demo.Run();

            Console.WriteLine();
            Console.WriteLine("Завдання 6. Adapter");
            Adapter.Demo.Run();

            Console.ReadKey();
        }
    }
}
