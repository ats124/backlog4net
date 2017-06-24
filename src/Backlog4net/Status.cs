﻿using System;
namespace Backlog4net
{
    /// <summary>
    /// The interface for Backlog status data.
    /// </summary>
    public interface Status
    {
        int Id { get; }

        string IdAsString { get; }

        string Name { get; }

        StatusType StatusType { get; }
    }
}
