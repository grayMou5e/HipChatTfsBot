using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.Entities;

namespace HipChat.TfsBot.Domain.TfsMessageBuilders
{
    public class PullRequestUpdateMessageBuilder : ITfsMessageBuilder
    {
        private string _message;

        public PullRequestUpdateMessageBuilder(string message)
        {
            _message = message;
        }

        public HipChatMessage Create()
        {
            Color color = Color.yellow;
            bool notify = false;
            if (_message.Contains("Merge status: Succeeded"))
            {
                color = Color.green;
                notify = true;
            }

            return HipChatMessage.Create(color, _message, notify, MessageFormat.html);
        }
    }
}
