namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystemNames
{
    public const string UploadSubsystem = "Upload";
    public const string MediaIdentificationSubsystem = "MediaIdentification";
    public const string TranscodingVideoSubsystem = "TranscodingVideo";
    public const string TranscodingAudioSubsystem = "TranscodingAudio";
    public const string MediaFileIndexingSubsystem = "MediaFileIndexing";
    public const string MediaFilePackagingSubsystem = "MediaFilePackaging";
    public const string RecognitionSubsystem = "Recognition";
    public const string DiarizationSubsystem = "Diarization";

    public const string RawRecognitionSubsystem = "RawRecognition";
    public const string RawDiarizationSubsystem = "RawDiarization";

    public const string NanoGridCombinedSubsystem = "NanoGrid";

    public const string SpeakerIdentificationSubsystem = "SpeakerIdentification";
    public const string SppSubsystem = "Spp";

    public const string TranscriptionStreamingSubsystem = "TranscriptionStreaming";
    public const string LiveSubtitlesStreamingSubsystem = "LiveSubtitlesStreaming";
    public const string LiveTranscriptionStreamingSubsystem = "LiveTranscriptionStreaming";

    public const string TranscriptionTracking = "TranscriptionTracking";
    public const string TranscriptionTimeLogging = "TranscriptionTimeLogging";
    public const string TranscriptionCreation = "TranscriptionCreation";
    public const string ProjectStatusMonitor = "ProjectStatusMonitor";
    public const string VoiceprintAggregation = "VoiceprintAggregation";
    public const string TranscriptionQueueTrackingSubsystem = "TranscriptionQueueTracking";
    public const string LowQualityAudioSubsystem = "LowQualityAudio";
    public const string SceneDetectionSubsystem = "SceneDetection";

    public const string TranscodingGroup = "Transcoding";
    public const string TranscribingGroup = "Transcribing";
    public const string RecognitionGroup = "Recognition";
    public const string PostprocessingGroup = "Posprocessing";
    public const string PackagingGroup = "Packaging";
    public const string TextCreationGroup = "TextCreation";
    public const string ChainControl = "ChainControl";

    // Virtual subsystems
    public const string CreditReservation = "CreditReservation";

    public const string ProjectUpdates = "ProjectUpdates";
}
