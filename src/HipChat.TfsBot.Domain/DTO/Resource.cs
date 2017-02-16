using System.Collections.Generic;

namespace HipChat.TfsBot.Domain.DTO
{
    public class Resource
    {
        public Repository repository { get; set; }
        public int pullRequestId { get; set; }
        public string status { get; set; }
        public CreatedBy createdBy { get; set; }
        public string creationDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string sourceRefName { get; set; }
        public string targetRefName { get; set; }
        public string mergeStatus { get; set; }
        public string mergeId { get; set; }
        public LastMergeSourceCommit lastMergeSourceCommit { get; set; }
        public LastMergeTargetCommit lastMergeTargetCommit { get; set; }
        public LastMergeCommit lastMergeCommit { get; set; }
        public List<Reviewer> reviewers { get; set; }
        public List<Commit> commits { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
    }
}
