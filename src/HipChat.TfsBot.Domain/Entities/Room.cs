using System;

namespace HipChat.TfsBot.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public int RoomId { get; set; }
        public string AuthToken { get; set; }
        public string Secret { get; set; }
    }
}
