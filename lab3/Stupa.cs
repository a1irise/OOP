namespace lab3
{
    class Stupa : AirTransport
    {
        public Stupa() : base("Stupa", 8) { }

        public override double DistanceReducer(double distance)
        {
            return 0.94 * distance;
        }
    }
}