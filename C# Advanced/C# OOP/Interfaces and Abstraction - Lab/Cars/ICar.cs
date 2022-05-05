using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02.Cars
{
    public interface ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        string Start();
        string Stop();

        void ToString();

    }
}
