using HipChat.TfsBot.Domain.ChatOptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HipChat.TfsBot.Domain.Entities
{
    public class HipChatMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "color")]
        public Color NotificationColor { get; private set; }

        public string Message { get; private set; }

        public bool Notify { get; private set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "message_format")]
        public MessageFormat MessageFormat { get; private set; }

        private HipChatMessage(Color color,string message, bool notify, MessageFormat messageFormat)
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
    }
}
