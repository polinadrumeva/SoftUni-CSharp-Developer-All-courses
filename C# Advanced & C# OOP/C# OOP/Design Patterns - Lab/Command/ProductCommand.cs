namespace Command
{
    using static Command.ICommand;

    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly decimal amount;

        public ProductCommand(Product product, PriceAction priceAction, decimal amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else if (priceAction == PriceAction.Decrease)
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
