using System;
using System.Dynamic;

namespace HipChat.TfsBot.Domain.Entities
{
    public class HipChatUrl
    {
        public string Url { get; }

        private HipChatUrl(string url)
        {
            Url = url;
        }

        public static HipChatUrl Create(Room room, string urlPattern)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (string.IsNullOrWhiteSpace(urlPattern)) throw new ArgumentNullException(nameof(urlPattern));

            var url = urlPattern
                .Replace($"##{nameof(room.RoomId)}##", room.RoomId.ToString())
                .Replace($"##{nameof(room.AuthToken)}##", room.AuthToken);

            return new HipChatUrl(url);
        }
    }
}