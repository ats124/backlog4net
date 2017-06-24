﻿﻿using System;
namespace Backlog4net
{
    public interface CustomField
    {
        long Id { get; }
        string IdAsString { get; }
        string Name { get; }
        int FieldTypeId { get; }
        FieldType Type { get; }
    }

	public enum FieldType
	{
		Text = 1,
		TextArea = 2,
		Numeric = 3,
		Date = 4,
		SingleList = 5,
		MultipleList = 6,
		ChexkBox = 7,
		Radio = 8
	}
}
