namespace lab3
{
    interface ITransport
    {
        public double GetRaceTime(double distance);
    }

    interface IGroundTransport : ITransport
    {
        public double RestTime();
    }

    interface IAirTransport : ITransport
    {
        public double DistanceReducer(double distance);
    }
}