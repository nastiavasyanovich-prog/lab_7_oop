using System;

namespace Patterns.Adapter
{
    interface ICelsiusSensor
    {
        double GetCelsius();
    }

    class FahrenheitSensor
    {
        public double ReadFahrenheit()
        {
            return 68.0;
        }
    }

    class KelvinSensor
    {
        public double MeasureKelvin()
        {
            return 300.15;
        }
    }

    class FahrenheitAdapter : ICelsiusSensor
    {
        private FahrenheitSensor sensor;

        public FahrenheitAdapter(FahrenheitSensor sensor)
        {
            this.sensor = sensor;
        }

        public double GetCelsius()
        {
            return (sensor.ReadFahrenheit() - 32) * 5 / 9;
        }
    }

    class KelvinAdapter : ICelsiusSensor
    {
        private KelvinSensor sensor;

        public KelvinAdapter(KelvinSensor sensor)
        {
            this.sensor = sensor;
        }

        public double GetCelsius()
        {
            return sensor.MeasureKelvin() - 273.15;
        }
    }

    class WeatherStation
    {
        public void Report(string name, ICelsiusSensor sensor)
        {
            Console.WriteLine("{0}: {1:F1} C", name, sensor.GetCelsius());
        }
    }

    static class Demo
    {
        public static void Run()
        {
            WeatherStation station = new WeatherStation();
            station.Report("Датчик Фаренгейта", new FahrenheitAdapter(new FahrenheitSensor()));
            station.Report("Датчик Кельвіна", new KelvinAdapter(new KelvinSensor()));
        }
    }
}
