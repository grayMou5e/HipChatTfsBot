using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.Handlers;
using HipChat.TfsBot.Domain.TfsMessageBuilders;
using System.Threading.Tasks;

namespace HipChat.TfsBot.Domain.Entities
{
    public class HipChatMessage
    {
        public Color NotificationColor { get; private set; }

        public string Message { get; private set; }

        public bool Notify { get; private set; }

        public MessageFormat MessageFormat { get; private set; }

        private HipChatMessage(Color color, string message, bool notify, MessageFormat messageFormat)
        {
            NotificationColor = color;
            Message = message;
            Notify = notify;
            MessageFormat = messageFormat;
        }

        public static HipChatMessage Create(Color color, string message, bool notify, MessageFormat messageFormat)
        {
            return new HipChatMessage(color, message, notify, messageFormat);
        }

        public static HipChatMessage Create(string message, bool notify, MessageFormat messageFormat, ITfsMessageBuilder builder)
        {
            return builder.Create(message, notify, messageFormat);
        }

        public async Task SendAsync(IRequestHandler handler)
        {
            await handler.SendAsync(NotificationColor, Message, Notify, MessageFormat);
        }
    }
}
