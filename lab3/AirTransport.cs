namespace lab3
{
    abstract class AirTransport : IAirTransport
    {
        public readonly string Name;
        private readonly double Speed;

        protected AirTransport(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract double DistanceReducer(double distance);

        public double GetRaceTime(double distance)
        {
            return DistanceReducer(distance) / Speed;
        }
    }
}