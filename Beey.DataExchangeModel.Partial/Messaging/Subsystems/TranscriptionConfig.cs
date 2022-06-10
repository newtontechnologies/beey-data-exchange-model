#pragma warning disable nullable
#pragma warning disable 8618
using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems
{
    public record TranscriptionConfig(bool SaveTrsx, string Language, string Profile, bool WithPPC, bool WithVAD, bool WithPunctuation, int UserId, bool TrialTranscription, bool WithSpeakerId, bool WithDiarization)
    {

    }
}
