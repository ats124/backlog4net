using System;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api
{
    /// <summary>
    /// Executes Backlog Git APIs.
    /// </summary>
    public interface GitMethods
    {
        /// <summary>
        /// Returns the git repositories in the project.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <returns>the git repositories in a list.</returns>
        /// <exception cref="BacklogException"></exception>
        ResponseList<Repository> GetGitRepositories(object projectIdOrKey);

        /// <summary>
        /// Returns the git repository.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <returns></returns>
        Repository GetGitRepository(object projectIdOrKey, object repoIdOrName);
    }
}
