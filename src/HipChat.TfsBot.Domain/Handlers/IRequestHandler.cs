using HipChat.TfsBot.Domain.ChatOptions;
using System.Threading.Tasks;

namespace HipChat.TfsBot.Domain.Handlers
{
    public interface IRequestHandler
    {
        Task SendAsync(Color color, string message, bool notify, MessageFormat messageFormat);
    }
}
