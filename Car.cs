namespace CarFactory
{
    public class Car
    {
        private IEngine _engine;
        private int _speed;
        private bool _isRunning;

        public Car(IEngine engine)
        {
            _engine = engine;
            _speed = 0;
            _isRunning = false;
        }
        public void SetEngine(IEngine engine)
        {
            _engine = engine;
            Console.WriteLine($"Engine replaced with new engine ({_engine})");
        }
        public void Start()
        {
            if (_isRunning)
            {
                Console.WriteLine("Car is already running.");
                return;
            }
            _isRunning = true;
            _speed = 0;
            Console.WriteLine($"Car started (Speed: {_speed} km/h | Engine: {_engine})");
        }
        public void Stop()
        {
            if (!_isRunning)
            {
                Console.WriteLine("Car is already stopped");
                return;
            }
            if (_speed != 0)
            {
                Console.WriteLine($"Cannot stop, Speed must be 0 first. (Current speed: {_speed} km/h)");
                return;
            }
            _isRunning = false;
            Console.WriteLine("Car stopped");
        }
        public void Accelerate()
        {
            if (!_isRunning)
            {
                Console.WriteLine("Cannot accelerate, Car is not running.");
                return;
            }
            if (_speed == 200)
            {
                Console.WriteLine("Already at max speed (200 km/h).");
                return;
            }
            int steps = 20;
            for (int i = 0; i < steps; i++)
            {
                _engine.Increase();
            }
            _speed = Math.Min(_speed + 20, 200);
            Console.WriteLine($"Accelerated (Speed: {_speed} km/h | Engine: {_engine})");
        }
        public void Brake()
        {
            if (!_isRunning)
            {
                Console.WriteLine("Cannot brake, Car is not running.");
                return;
            }
            if (_speed == 0)
            {
                Console.WriteLine("Already at 0 km/h.");
                return;
            }
            int steps = 20;
            for (int i = 0; i < steps; i++)
            {
                _engine.Decrease();
            }
            _speed = Math.Max(_speed - 20, 0);
            Console.WriteLine($"Braked (Speed: {_speed} km/h | Engine: {_engine})");
        }
    }
}
