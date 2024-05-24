namespace Beey.DataExchangeModel.Messaging.Subsystems;

public record TranscriptionConfig(
    bool SaveTrsx,
    string Language,
    string Profile,
    bool WithPPC,
    bool WithVAD,
    bool WithPunctuation,
    int UserId,
    bool TrialTranscription,
    bool WithSpeakerId,
    bool WithDiarization,
    bool WithUserLex
    );
