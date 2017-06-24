using System;
using Newtonsoft.Json;
namespace Backlog4net.Internal.Json.customFields
{
    public abstract class CustomFieldSettingJsonImpl : CustomFieldSetting
    {
        [JsonProperty]
        public long Id { get; private set; }

        public string IdAsString => Id.ToString();

		[JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
		public long[] ApplicableIssueTypes { get; private set; }

		[JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public bool IsRequired { get; private set; }

        public abstract int FieldTypeId { get; }
        public abstract FieldType Type { get; }
    }
}
