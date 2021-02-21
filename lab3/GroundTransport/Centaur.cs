namespace lab3
{
    class Centaur : GroundTransport
    {
        public Centaur() : base("Centaur", 15, 8) { }

        public override double RestTime()
        {
            return 2;
        }
    }
}