using System;
using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.DTO;
using HipChat.TfsBot.Domain.Entities;

namespace HipChat.TfsBot.Domain.TfsMessageBuilders
{
    public class PullRequestUpdateMessageBuilder : ITfsMessageBuilder
    {
        private readonly PullRequest _pullRequest;
        private readonly string _message;

        public PullRequestUpdateMessageBuilder(PullRequest pullRequest)
        {
            if (pullRequest == null) throw new ArgumentNullException(nameof(pullRequest));

            _pullRequest = pullRequest;
        }

        public HipChatMessage Create()
        {
            var color = Color.yellow;
            var notify = false;

            if (_pullRequest.resource.status.ToLower() == "completed")
            {
                color = Color.green;
                notify = true;
            }

            return HipChatMessage.Create(color, _pullRequest.detailedMessage.html, notify, MessageFormat.html);
        }
    }
}
