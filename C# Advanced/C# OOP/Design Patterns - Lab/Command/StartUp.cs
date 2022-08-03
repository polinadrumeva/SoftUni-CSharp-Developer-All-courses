namespace Command
{
    using System;


    public class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 1000);

            Execute(product, modifyPrice, new ProductCommand(product, ICommand.PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, ICommand.PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, ICommand.PriceAction.Decrease, 20));
            Execute(product, modifyPrice, new ProductCommand(product, ICommand.PriceAction.Decrease, 10));
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ProductCommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
