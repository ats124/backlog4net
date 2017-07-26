﻿using System;
using System.Collections.Generic;

namespace Backlog4net
{
    public interface CustomField
    {
        long Id { get; }
        string IdAsString { get; }
        string Name { get; }
        CustomFieldType FieldType { get; }
    }

	public enum CustomFieldType
	{
		Text = 1,
		TextArea = 2,
		Numeric = 3,
		Date = 4,
		SingleList = 5,
		MultipleList = 6,
		CheckBox = 7,
		Radio = 8
	}

    public interface ListItem
    {
        long Id { get; }

        string Name { get; }

        int DisplayOrder { get; }
    }

    public interface CheckBoxCustomField : CustomField
    {
        IList<ListItem> Value { get; }

        string OtherValue { get; }
    }

    public interface DateCustomField : CustomField
    {
        DateTime Value { get; }
    }

    public interface MultipleListCustomField : CustomField
    {
        IList<ListItem> Value { get; }
    }

    public interface NumericCustomField : CustomField
    {
        decimal Value { get; }
    }

    public interface RadioCustomField : CustomField
    {
        ListItem Value { get; }

        string OtherValue { get; }
    }

    public interface SingleListCustomField : CustomField
    {
        ListItem Value { get; }
    }

    public interface TextAreaCustomField : CustomField
    {
        string Value { get; }
    }

    public interface TextCustomField : CustomField
    {
        string Value { get; }
    }
}
