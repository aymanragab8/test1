namespace CarFactory
{
    public class HybridEngine : IEngine
    {
        private readonly GasEngine _gas = new();
        private readonly ElectricEngine _electric = new();

        public int Speed => GetActiveEngine().Speed;


        private IEngine GetActiveEngine()
        {
            int currentSpeed = _electric.Speed + _gas.Speed;
            return (_electric.Speed < 50 && _gas.Speed == 0) || (_electric.Speed > 0 && _electric.Speed < 50) ? _electric : _gas;
        }
        public void Decrease()
        {
            int currentSpeed = Speed;
            if (currentSpeed >= 50)
            {
                _gas.Decrease();

                if (_gas.Speed < 50)
                {
                    while (_electric.Speed < _gas.Speed) _electric.Increase();
                    while (_gas.Speed > 0) _gas.Decrease();
                }
            }
            else
            {
                _electric.Decrease();
            }
        }

        public void Increase()
        {
            int currentSpeed = Speed;
            if (currentSpeed < 50)
            {
                _electric.Increase();

                if (_electric.Speed == 50)
                {
                    while (_gas.Speed < _electric.Speed) _gas.Increase();
                    while (_electric.Speed > 0) _electric.Decrease();
                }
            }
            else
            {
                _gas.Increase();
            }
        }
        public override string ToString()
        {
            string activeEngine = Speed < 50 ? "Electric Engine" : "Gas Engine";
            return $"Hybrid Engine ({activeEngine})";
        }

    }
}
