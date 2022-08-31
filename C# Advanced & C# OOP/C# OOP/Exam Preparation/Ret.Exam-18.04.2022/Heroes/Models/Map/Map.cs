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
            bool areDeathBarbarian = false;

            foreach (var hero in heroes)
            {
                if (hero.GetType().Name == "Barbarian")
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

                    if (barbarians.All(h => h.IsAlive == false))
                    {
                        areDeathBarbarian = true;
                        break;
                    }
                }

                if (areDeathBarbarian)
                {
                    break;
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
                    if (knights.All(h => h.IsAlive == false))
                    {
                        break;
                    }
                }

            }

            int deathKnigts = knights.Count() - knights.Where(x => x.IsAlive).Count();
            int deathBarbarian = barbarians.Count() - barbarians.Where(x => x.IsAlive).Count();

            if (knights.Any(x => x.IsAlive))
            {
                return $"The knights took {deathKnigts} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {deathBarbarian} casualties but won the battle.";
            }
        }
    }
    
}
