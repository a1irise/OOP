namespace lab3
{
    class BactrianCamel : GroundTransport
    {
        public BactrianCamel() : base("Bactrian camel", 10, 30) { }

        private bool isFirstRest = true;

        public override double RestTime()
        {
            if (!isFirstRest)
                return 8;
            
            isFirstRest = false;
            return 5;
        }
    }
}