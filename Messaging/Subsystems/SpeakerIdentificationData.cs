﻿using Beey.DataExchangeModel.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    class SpeakerIdentificationData : SubsystemData<SpeakerIdentificationData>
    {
        public string XmlSpeaker { get; set; }
        public int AsrMsgId { get; set; }

        public override void Initialize(JsonData data, JsonSerializerOptions options = null)
        {
            AsrMsgId = data.JsonElement.GetProperty(nameof(AsrMsgId)).GetInt32();
            if (data.JsonElement.TryGetProperty(nameof(XmlSpeaker), out var xmlSpeakerProp))
                XmlSpeaker = xmlSpeakerProp.GetString();
        }
    }
}
