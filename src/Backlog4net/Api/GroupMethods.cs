using System;
using System.Collections.Generic;
using System.Text;

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
        /// <returns>the groups in a list.</returns>
        ResponseList<Group> GetGroups();

        /// <summary>
        /// Returns all the groups.
        /// </summary>
        /// <param name="params">the offset parameters</param>
        /// <returns>the groups in a list.</returns>
        ResponseList<Group> GetGroups(OffsetParams @params);

        /// <summary>
        /// Creates a group.
        /// </summary>
        /// <param name="params">the group creating parameters</param>
        /// <returns>the created Group</returns>
        Group CreateGroup(CreateGroupParams @params);

        /// <summary>
        /// Returns the groups identified by the group's id.
        /// </summary>
        /// <param name="groupId">the group identifier</param>
        /// <returns>the Group.</returns>
        Group GetGroup(object groupId);

        /// <summary>
        /// Updates the existing group.
        /// </summary>
        /// <param name="params">the group updating parameters</param>
        /// <returns>the updated Group.</returns>
        Group UpdateGroup(UpdateGroupParams @params);

        /// <summary>
        /// Deletes the existing groups.
        /// </summary>
        /// <param name="groupId">the group identifier</param>
        /// <returns>the deleted Group.</returns>
        Group DeleteGroup(object groupId);
    }
}
