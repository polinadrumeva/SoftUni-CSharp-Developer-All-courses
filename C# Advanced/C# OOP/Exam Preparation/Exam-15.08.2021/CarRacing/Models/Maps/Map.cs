namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.RaceCannotBeCompleted);
            }
            
                racerOne.Race();
                racerTwo.Race();
            

            double racingMutiplierFirstPlayer = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                racingMutiplierFirstPlayer = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingMutiplierFirstPlayer = 1.1;
            }
            double chanceOfWinningFirstPlayer = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingMutiplierFirstPlayer;

            double racingMutiplierSecondPlayer = 0;
            if (racerTwo.RacingBehavior == "strict")
            {
                racingMutiplierSecondPlayer = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingMutiplierSecondPlayer = 1.1;
            }
            double chanceOfWinningSecondPlayer = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingMutiplierFirstPlayer;

            if (chanceOfWinningFirstPlayer > chanceOfWinningSecondPlayer)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else if (chanceOfWinningFirstPlayer < chanceOfWinningSecondPlayer)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }

            return null;
        }
    }
}
