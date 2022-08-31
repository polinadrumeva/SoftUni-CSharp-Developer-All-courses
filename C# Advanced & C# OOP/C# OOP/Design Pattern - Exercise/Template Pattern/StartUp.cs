using System;

namespace Template_Pattern
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.Make();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
        }
    }
}
