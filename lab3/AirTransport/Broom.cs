namespace lab3
{
    class Broom : AirTransport
    {
        public Broom() : base("Broom", 20) { }

        public override double DistanceReducer(double distance)
        {
            for (int i = 0; i < distance / 1000; i++)
                distance *= 0.99;
            return distance;
        }
    }
}
