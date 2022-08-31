using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class TheStationaryPhone : IStationarPhone
    {
        public string Call(string number)
        {
            if (!this.ValidateNumber(number))
            {
                return $"Invalid number!";
            }

            return $"Dialing... {number}";
        }

        private bool ValidateNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
