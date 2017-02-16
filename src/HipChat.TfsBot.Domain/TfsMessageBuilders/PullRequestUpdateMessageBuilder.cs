using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.Entities;

namespace HipChat.TfsBot.Domain.TfsMessageBuilders
{
    public class PullRequestUpdateMessageBuilder : ITfsMessageBuilder
    {
        public HipChatMessage Create(string message, bool notify, MessageFormat format)
        {
            Color color = Color.yellow;
            if (message.Contains("Merge status: Succeeded"))
            {
                color = Color.green;
            }

            return HipChatMessage.Create(color, message, notify, format);
        }
    }
}
