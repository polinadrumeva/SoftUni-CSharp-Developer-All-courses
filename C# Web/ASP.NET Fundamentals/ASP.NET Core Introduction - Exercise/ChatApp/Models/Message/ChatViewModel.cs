namespace ChatApp.Models.Message
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            this.AllMessages = new List<MessageViewModel>();
        }
        public MessageViewModel CurrentMessage { get; set; } = null!;

        public ICollection<MessageViewModel> AllMessages { get; set; } = null!;
    }
}
