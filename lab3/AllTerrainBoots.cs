namespace lab3
{
    class AllTerrainBoots : GroundTransport
    {
        public AllTerrainBoots() : base("All-terrain boots", 6, 60) { }

        private bool isFirstRest = true;

        public override double RestTime()
        {
            if (!isFirstRest)
                return 5;

            isFirstRest = false;
            return 10;
        }
    }
}