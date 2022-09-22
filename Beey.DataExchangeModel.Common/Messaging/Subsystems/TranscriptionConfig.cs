

using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Beey.DataExchangeModel.Messaging.Subsystems;

public record TranscriptionConfig
{
    public TranscriptionConfig(bool saveTrsx, string language, string profile, bool withPPC, bool withVAD, bool withPunctuation, int userId, bool trialTranscription, bool withSpeakerId, bool withDiarization)
    {
        SaveTrsx = saveTrsx;
        Language = language;
        Profile = profile;
        WithPPC = withPPC;
        WithVAD = withVAD;
        WithPunctuation = withPunctuation;
        UserId = userId;
        TrialTranscription = trialTranscription;
        WithSpeakerId = withDiarization && withSpeakerId;
        WithDiarization = withDiarization;
    }

    public bool SaveTrsx { get; }
    public string Language { get; }
    public string Profile { get; }
    public bool WithPPC { get; }
    public bool WithVAD { get; }
    public bool WithPunctuation { get; }
    public int UserId { get; }
    public bool TrialTranscription { get; }
    public bool WithSpeakerId { get; }
    public bool WithDiarization { get; }
}
