namespace lab3
{
    class MagicCarpet : AirTransport
    {
        public MagicCarpet() : base("Magic carpet", 10) { }

        public override double DistanceReducer(double distance)
        {
            if (distance < 1000)
                return distance;
            
            if (distance < 5000)
                return 0.97 * distance;

            if (distance < 10000)
                return 0.9 * distance;

            return 0.95 * distance;
        }
    }
}