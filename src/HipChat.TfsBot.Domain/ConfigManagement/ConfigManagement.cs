using System.Configuration;

namespace HipChat.TfsBot.Domain.ConfigManagement
{
    public class ConfigManagement
    {
        public static string SqlConnectionString => ConfigurationManager.AppSettings["SqlConnectionString"];
        public static string HipChatUrl => ConfigurationManager.AppSettings["HipChatUrl"];
    }
}