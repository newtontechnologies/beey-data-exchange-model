﻿using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Common.Serialization.JsonConverters;
using Beey.DataExchangeModel.Common.Transcriptions;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public enum NgTrack { Recognition, Diarization, Voiceprints };

public class NanoGridData : SubsystemData<NanoGridData>
{
    public NgTrack Track { get; set; } = default!;

    [JsonConverter(typeof(JsonNgItemConverter))]
    public IEnumerable<NgItem> Items { get; set; } = default!;
}
