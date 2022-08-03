using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            List<Barbarian> barbarians = new List<Barbarian>();
            List<Knight> knights = new List<Knight>();

            foreach (var hero in heroes)
            {
                if (hero is Barbarian)
                {
                    barbarians.Add((Barbarian)hero);
                }
                else
                {
                    knights.Add((Knight)hero);
                }
            }

            while (knights.Any(x => x.IsAlive) || barbarians.Any(x => x.IsAlive))
            {
                foreach (var knight in knights)
                {
                    foreach (var barbarian in barbarians)
                    {
                        if (knight.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }

                    }
                }

                foreach (var barbarian in barbarians)
                {
                    foreach (var knight in knights)
                    {
                        if (barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

            }

            if (knights.Any(x => x.IsAlive))
            {
                return $"The knights took {knights.Where(k => k.IsAlive).ToList().Count} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {barbarians.Where(b => b.IsAlive).ToList().Count} casualties but won the battle.";
            }
        }
    }
    
}
