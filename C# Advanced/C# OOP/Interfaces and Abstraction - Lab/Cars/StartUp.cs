using System;

namespace L02.Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            seat.ToString();
            tesla.ToString();

        }
    }
}
