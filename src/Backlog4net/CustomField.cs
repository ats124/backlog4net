﻿using System;
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
}
