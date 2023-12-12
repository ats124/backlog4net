using System;
namespace Backlog4net
{
    /// <summary>
    /// Supports to get url for web link.
    /// </summary>
    public interface BacklogUrlSupport
    {
		// https://spacexxx.backlog.com/git/TEST_PROJECT/app_repository/pullRequests/123
		String GetPullRequestUrl(Project project, Repository repository, PullRequest pullRequest);

		// https://spacexxx.backlog.com/git/TEST_PROJECT/app_repository/pullRequests/123#comment-1074239043
		String GetPullRequestCommentUrl(Project project, Repository repository, PullRequest pullRequest, PullRequestComment pullRequestComment);

		// https://spacexxx.backlog.com/view/TEST_PROJECT-123
		String GetIssueUrl(Issue issue);

		// https://spacexxx.backlog.com/view/TEST_PROJECT-123#comment-1212
		String GetIssueCommentUrl(Issue issue, IssueComment issueComment);

		// https://spacexxx.backlog.com/wiki/TEST_PROJECT/Home
		String GetWikiUrl(Project project, Wiki wiki);
    }
}
