using System;
using System.Net.Http.Headers;
using HipChat.TfsBot.Domain.Extensions;

namespace HipChat.TfsBot.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; }
        public int RoomId { get; }
        public string AuthToken { get; }
        public string Secret { get; }

        private Room(Guid id, int roomId, string authToken, string secret)
        {
            if (authToken == null) throw new ArgumentNullException(nameof(authToken));
            if (string.IsNullOrWhiteSpace(secret)) throw new ArgumentNullException(nameof(secret));
            if (roomId == 0) throw new ArgumentException("Room id cannot be set to 0");
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty guid");

            Id = id;
            RoomId = roomId;
            AuthToken = authToken;
            Secret = secret;
        }

        public static Room Create(Guid id, int roomId, string authToken, string secret)
        {
            return new Room(id, roomId, authToken, secret.Sha512());
        }

        public static Room CreateWithHashedSecret(Guid id, int roomId, string authToken, string secret)
        {
            return new Room(id, roomId, authToken, secret);
        }
    }
}
