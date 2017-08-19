﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json
{
    public class WebhookJsonImpl : Webhook
    {
        internal class JsonConverter : InterfaceConverter<Webhook, WebhookJsonImpl> { }

        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public string HookUrl { get; private set; }

        [JsonProperty("allEvent")]
        public bool IsAllEvent { get; private set; }

        [JsonProperty]
        public ActivityType[] ActivityTypeIds { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User CreatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Created { get; private set; }

        [JsonProperty, JsonConverter(typeof(UserJsonImpl.JsonConverter))]
        public User UpdatedUser { get; private set; }

        [JsonProperty]
        public DateTime? Updated { get; private set; }
    }
}
