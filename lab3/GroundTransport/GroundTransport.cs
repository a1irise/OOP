namespace lab3
{
    abstract class GroundTransport : IGroundTransport
    {
        public readonly string Name;
        private readonly double Speed;
        private readonly double RestInterval;
        
        protected GroundTransport(string name, double speed, double restInterval)
        {
            Name = name;
            Speed = speed;
            RestInterval = restInterval;
        }   
        
        public abstract double RestTime();

        public double GetRaceTime(double distance)
        {
            double raceTime = 0;
            double remainingDistance = distance;
            double maxDistanceUntilRest = Speed * RestInterval;

            while (remainingDistance > 0)
            {
                if (remainingDistance > maxDistanceUntilRest)
                {
                    remainingDistance -= maxDistanceUntilRest;
                    raceTime += RestInterval + RestTime();
                }
                else
                {
                    raceTime += remainingDistance / Speed;
                    break;
                }
            }

            return raceTime;
        }
    }
}