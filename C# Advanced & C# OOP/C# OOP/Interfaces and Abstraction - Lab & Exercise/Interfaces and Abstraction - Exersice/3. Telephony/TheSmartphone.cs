using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class TheSmartphone : ISmartphone
    {
        public string Call(string number)
        {
            if (!this.ValidateNumber(number))
            {
                return $"Invalid number!";
            }

            return $"Calling... {number}";
        }

        public string SearchWeb(string web)
        {
            if (!this.ValidateWeb(web))
            {
                return $"Invalid URL!";
            }

            return $"Browsing: {web}!";
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

        private bool ValidateWeb(string web)
        {
            foreach (var symbol in web)
            {
                if (Char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;   
        }
    }
}
