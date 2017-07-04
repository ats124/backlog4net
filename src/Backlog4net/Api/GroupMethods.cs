using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backlog4net.Api
{
    using Option;

    /// <summary>
    /// Executes Backlog Group APIs.
    /// </summary>
    public interface GroupMethods
    {
        /// <summary>
        /// Returns all the groups.
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the groups in a list.</returns>
        Task<ResponseList<Group>> GetGroupsAsync(OffsetParams @params = null, CancellationToken? token = null);

        /// <summary>
        /// Creates a group.
        /// </summary>
        /// <param name="params">the group creating parameters</param>
        /// <returns>the created Group</returns>
        Task<Group> CreateGroupAsync(CreateGroupParams @params, CancellationToken? token = null);

        /// <summary>
        /// Returns the groups identified by the group's id.
        /// </summary>
        /// <param name="groupId">the group identifier</param>
        /// <returns>the Group.</returns>
        Task<Group> GetGroupAsync(object groupId, CancellationToken? token = null);

        /// <summary>
        /// Updates the existing group.
        /// </summary>
        /// <param name="params">the group updating parameters</param>
        /// <returns>the updated Group.</returns>
        Task<Group> UpdateGroupAsync(UpdateGroupParams @params, CancellationToken? token = null);

        /// <summary>
        /// Deletes the existing groups.
        /// </summary>
        /// <param name="groupId">the group identifier</param>
        /// <returns>the deleted Group.</returns>
        Task<Group> DeleteGroupAsync(object groupId, CancellationToken? token = null);
    }
}
