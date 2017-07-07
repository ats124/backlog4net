﻿using System;
namespace Backlog4net
{
    public interface CustomFieldSetting : CustomField
    {
        string Description { get; }
        bool IsRequired { get; }
        long[] ApplicableIssueTypes { get; }
    }
}
