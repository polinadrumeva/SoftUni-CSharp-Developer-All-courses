namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double oxygenBiologist = 70;
        private const double decreaseOxygenBiologist = 5;
        public Biologist(string name)
            : base(name, oxygenBiologist)
        {
        }
        public override void Breath()
        {
            this.Oxygen -= decreaseOxygenBiologist;
        }

    }
}
