namespace WildFarm.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Models.Foods;

    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
