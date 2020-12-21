namespace lab3
{
    class FastCamel : GroundTransport
    {
        public FastCamel() : base("Fast camel", 40, 10) { }

        private bool isFirstRest = true;
        private bool isSecondRest;
        
        public override double RestTime()
        {
            if (isFirstRest)
            {
                isFirstRest = false;
                isSecondRest = true;
                return 5;
            }

            if (isSecondRest)
            {
                isSecondRest = false;
                return 6.5;
            }

            return 8;
        }
    }
}