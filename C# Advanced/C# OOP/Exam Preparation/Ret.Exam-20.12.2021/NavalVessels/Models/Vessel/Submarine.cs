namespace NavalVessels.Models.Vessel
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Submarine : Vessel, ISubmarine
    {
        private const double defaultArmorSubmarine = 200;
        private bool submergeMode = false;
        public bool SubmergeMode
        {
            get
            {
                return this.submergeMode;
            }
            private set
            {
                this.submergeMode = value;
            }
        }

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, defaultArmorSubmarine)
        {
             
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmorSubmarine)
            {
                this.ArmorThickness = defaultArmorSubmarine;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(", ", this.Targets)}");
            }
            if (this.SubmergeMode)
            {
                sb.AppendLine(" *Submerge mode: ON");
            }
            else
            {
                sb.AppendLine(" *Submerge mode: OFF");
            }

            return sb.ToString();
        }
    }
}
