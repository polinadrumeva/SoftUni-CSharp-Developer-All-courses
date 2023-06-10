using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();
        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                AllMessages = messages.Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                }).ToArray()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Show");
            }

            var currentMessage = new KeyValuePair<string, string>(chatModel.CurrentMessage.Sender, chatModel.CurrentMessage.MessageText);
            messages.Add(currentMessage);

            return RedirectToAction("Show");
        }
    }
}
