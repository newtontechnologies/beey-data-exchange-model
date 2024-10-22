using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using Beey.DataExchangeModel.Common.Voiceprints;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public class SpeakerIdentificationConfig
{
    public string Language { get; set; }
    public string VoiceprintVersion { get; set; }
    public int SufficientSpeakerDuration { get; set; }
    public VoiceprintModelInfo[] VoiceprintModels { get; set; }
}
