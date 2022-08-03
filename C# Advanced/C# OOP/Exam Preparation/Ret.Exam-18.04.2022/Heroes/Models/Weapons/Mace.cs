namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private int damage;

        public Mace(string name, int durability) 
            : base(name, durability)
        {
            damage = 25;
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
