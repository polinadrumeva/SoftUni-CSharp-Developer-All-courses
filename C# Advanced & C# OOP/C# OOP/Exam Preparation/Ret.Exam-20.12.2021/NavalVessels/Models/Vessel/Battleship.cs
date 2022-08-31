namespace NavalVessels.Models.Vessel
{
    using NavalVessels.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Battleship : Vessel, IBattleship
    {

        private const double defaultArmorBattleShip = 300;
        private bool sonarMode = false;
        public bool SonarMode
        {
            get 
            {
                return this.sonarMode;
            }
            private set 
            {
                this.sonarMode = value;
            }
        }

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, defaultArmorBattleShip)
        {
           
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmorBattleShip)
            {
                this.ArmorThickness = defaultArmorBattleShip;
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
            if (this.SonarMode)
            {
                sb.AppendLine(" *Sonar mode: ON");
            }
            else
            {
                sb.AppendLine(" *Sonar mode: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
