﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BeeyApi.POCO.Transcriptions
{
    public partial class NgRecoveryEvent : NgEvent
    {
        public TimeSpan Begin { get; set; }
        public NgRecoveryEvent() : base(null) { }
        public NgRecoveryEvent(JObject source) : base(source)
        {
            Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());
        }

        public override JObject Serialize()
        {
            return
                new JObject(
                    new JProperty("b", (long)Begin.TotalMilliseconds),
                    new JProperty("k", "r")
                    );
        }
    }
}
