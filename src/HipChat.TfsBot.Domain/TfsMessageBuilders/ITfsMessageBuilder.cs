using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.Entities;

namespace HipChat.TfsBot.Domain.TfsMessageBuilders
{
    public interface ITfsMessageBuilder
    {
        HipChatMessage Create();
    }
}