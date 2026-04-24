namespace CarFactory
{
    public interface IEngine
    {
        int Speed { get; }
        void Increase();
        void Decrease();
    }
}
