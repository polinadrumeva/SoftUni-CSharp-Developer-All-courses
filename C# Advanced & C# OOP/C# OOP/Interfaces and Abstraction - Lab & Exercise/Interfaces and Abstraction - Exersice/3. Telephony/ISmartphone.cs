using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartphone : IStationarPhone
    {
        string SearchWeb(string web);
    }
}
