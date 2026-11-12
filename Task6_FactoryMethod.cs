using System;

namespace Patterns.FactoryMethod
{
    interface ITransport
    {
        void Deliver(string cargo);
    }

    class Truck : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Вантажівка везе вантаж \"{0}\" дорогою", cargo);
        }
    }

    class Ship : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Корабель везе вантаж \"{0}\" морем", cargo);
        }
    }

    class Plane : ITransport
    {
        public void Deliver(string cargo)
        {
            Console.WriteLine("Літак везе вантаж \"{0}\" повітрям", cargo);
        }
    }

    abstract class Logistics
    {
        public abstract ITransport CreateTransport();

        public void PlanDelivery(string cargo)
        {
            ITransport transport = CreateTransport();
            transport.Deliver(cargo);
        }
    }

    class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    class AirLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }

    static class Demo
    {
        public static void Run()
        {
            Logistics logistics = new RoadLogistics();
            logistics.PlanDelivery("ноутбуки");

            logistics = new SeaLogistics();
            logistics.PlanDelivery("ноутбуки");

            logistics = new AirLogistics();
            logistics.PlanDelivery("ноутбуки");
        }
    }
}
