namespace Command
{
    public interface ICommand
    {
        void ExecuteAction();

        public enum PriceAction
        { 
            Increase,
            Decrease
        }
    }
}
