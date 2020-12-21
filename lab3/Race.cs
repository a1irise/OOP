using System;
using System.Collections.Generic;

namespace lab3
{
    class Race
    {
        private List<ITransport> participants = new List<ITransport>();

        public void AddParticipant(ITransport participant)
        {
            participants.Add(participant);
        }

        public ITransport StartRace(double distance)
        {
            ITransport winner = null;
            double minRaceTime = Double.MaxValue;

            foreach (var participant in participants)
            {
                if (participant.GetRaceTime(distance) < minRaceTime)
                {
                    minRaceTime = participant.GetRaceTime(distance);
                    winner = participant;
                }
            }

            return winner;
        }
    }
    
    class GroundRace
    {
        private List<IGroundTransport> participants = new List<IGroundTransport>();

        public void AddParticipant(IGroundTransport participant)
        {
            participants.Add(participant);
        }

        public ITransport StartRace(double distance)
        {
            ITransport winner = null;
            double minRaceTime = Double.MaxValue;

            foreach (var participant in participants)
            {
                if (participant.GetRaceTime(distance) < minRaceTime)
                {
                    minRaceTime = participant.GetRaceTime(distance);
                    winner = participant;
                }
            }

            return winner;
        }
    }
    
    class AirRace
    {
        private List<IAirTransport> participants = new List<IAirTransport>();

        public void AddParticipant(IAirTransport participant)
        {
            participants.Add(participant);
        }

        public ITransport StartRace(double distance)
        {
            ITransport winner = null;
            double minRaceTime = Double.MaxValue;

            foreach (var participant in participants)
            {
                if (participant.GetRaceTime(distance) < minRaceTime)
                {
                    minRaceTime = participant.GetRaceTime(distance);
                    winner = participant;
                }
            }

            return winner;
        }
    }
}