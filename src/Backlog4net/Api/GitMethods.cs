using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        Task<ResponseList<Repository>> GetGitRepositoriesAsync(object projectIdOrKey, CancellationToken? token = null);

        /// <summary>
        /// Returns the git repository.
        /// </summary>
        /// <param name="projectIdOrKey">the project identifier</param>
        /// <param name="repoIdOrName">the repository name</param>
        /// <returns></returns>
        Task<Repository> GetGitRepositoryAsync(object projectIdOrKey, object repoIdOrName, CancellationToken? token = null);
    }
}
