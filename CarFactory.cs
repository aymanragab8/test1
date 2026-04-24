namespace CarFactory
{
    public class CarFactory
    {
        public Car CreateCar(string engineType)
        {
            IEngine engine = CreateEngine(engineType);
            Console.WriteLine($"Car created with {engine}");
            return new Car(engine);
        }
        public void ReplaceEngine(Car car, string engineType)
        {
            IEngine newEngine = CreateEngine(engineType);
            car.SetEngine(newEngine);
        }
        private IEngine CreateEngine(string engineType)
        {
            return engineType.ToLower() switch
            {
                "gas" => new GasEngine(),
                "electric" => new ElectricEngine(),
                "hybrid" => new HybridEngine(),
                _ => throw new ArgumentException($"Unknown engine type: {engineType}")
            };
        }
    }
}
