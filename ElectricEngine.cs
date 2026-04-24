namespace CarFactory
{
    public class ElectricEngine : IEngine
    {
        public int Speed { get; private set; }

        public void Decrease()
        {
            if (Speed > 0)
                Speed--;
        }

        public void Increase()
        {
            Speed++;
        }

        public override string ToString()
        {
            return $"ElectricEngine";
        }
    }
}
