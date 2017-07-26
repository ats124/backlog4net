﻿using System;
using System.Collections.Generic;

namespace Backlog4net
{
    public interface CustomFieldSetting : CustomField
    {
        string Description { get; }
        bool IsRequired { get; }
        long[] ApplicableIssueTypes { get; }
    }

    public interface ListItemSetting
    {
        long Id { get; }

        string Name { get; }

        bool AllowInput { get; }

        int DisplayOrder { get; }
    }

    public interface CheckBoxCustomFieldSetting : CustomFieldSetting
    {
        IList<ListItemSetting> Items { get; }

        bool IsAllowInput { get; }

        bool IsAllowAddItem { get; }
    }

    public enum DateCustomFieldInitialValueType
    {
        Today = 1,
        TodayPlusShiftDays = 2,
        FixedDate = 3,
    }

    public interface DateValueSetting
    {
        long Id { get; }

        DateTime Date { get; }

        int Shift { get; }
    }

    public interface DateCustomFieldSetting : CustomFieldSetting
    {
        DateTime Min { get; }

        DateTime Max { get; }

        DateValueSetting InitialDate { get; }
    }

    public interface MultipleListCustomFieldSetting : CustomFieldSetting
    {
        IList<ListItemSetting> Items { get; }

        bool IsAllowAddItem { get; }
    }

    public interface NumericCustomFieldSetting : CustomFieldSetting
    {
        decimal Min { get; }

        decimal Max { get; }

        decimal InitialValue { get; }

        string Unit { get; }
    }

    public interface RadioCustomFieldSetting : CustomFieldSetting
    {
        IList<ListItemSetting> Items { get; }

        bool IsAllowInput { get; }

        bool IsAllowAddItem { get; }
    }

    public interface SingleListCustomFieldSetting : CustomFieldSetting
    {
        IList<ListItemSetting> Items { get; }

        bool IsAllowAddItem { get; }
    }

    public interface TextAreaCustomFieldSetting : CustomFieldSetting
    {
    }

    public interface TextCustomFieldSetting : CustomFieldSetting
    {
    }
}
