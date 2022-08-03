namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private int damage;

        public Claymore(string name, int durability)
            : base(name, durability)
        {
            damage = 20;
        }

        public override int DoDamage()
        {
            this.Durability--;
            if (this.Durability == 0)
            {
                return 0;
            }
            return damage;
        }
    }
}
