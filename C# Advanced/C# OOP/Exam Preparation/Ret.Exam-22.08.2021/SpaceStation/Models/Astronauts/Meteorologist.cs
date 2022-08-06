namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double oxygenMeteorologist = 90;
        public Meteorologist(string name)
            : base(name, oxygenMeteorologist)
        { 
        }
       
    }
}
