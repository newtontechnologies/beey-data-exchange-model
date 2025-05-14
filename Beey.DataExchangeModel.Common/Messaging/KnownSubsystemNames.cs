using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystemNames
{
    public static readonly SubsystemName UploadSubsystem = SubsystemName.Get("Upload");
    public static readonly SubsystemName MediaIdentificationSubsystem = SubsystemName.Get("MediaIdentification");
    public static readonly SubsystemName TranscodingVideoSubsystem = SubsystemName.Get("TranscodingVideo");
    public static readonly SubsystemName TranscodingAudioSubsystem = SubsystemName.Get("TranscodingAudio");
    public static readonly SubsystemName MediaFileIndexingSubsystem = SubsystemName.Get("MediaFileIndexing");
    public static readonly SubsystemName MediaFilePackagingSubsystem = SubsystemName.Get("MediaFilePackaging");
    public static readonly SubsystemName RecognitionSubsystem = SubsystemName.Get("Recognition");
    public static readonly SubsystemName DiarizationSubsystem = SubsystemName.Get("Diarization");

    public static readonly SubsystemName RawRecognitionSubsystem = SubsystemName.Get("RawRecognition");
    public static readonly SubsystemName RawDiarizationSubsystem = SubsystemName.Get("RawDiarization");

    public static readonly SubsystemName NanoGridCombinedSubsystem = SubsystemName.Get("NanoGrid");

    public static readonly SubsystemName SpeakerIdentificationSubsystem = SubsystemName.Get("SpeakerIdentification");
    public static readonly SubsystemName SppSubsystem = SubsystemName.Get("Spp");

    public static readonly SubsystemName TranscriptionStreamingSubsystem = SubsystemName.Get("TranscriptionStreaming");
    public static readonly SubsystemName LiveSubtitlesStreamingSubsystem = SubsystemName.Get("LiveSubtitlesStreaming");
    public static readonly SubsystemName LiveTranscriptionStreamingSubsystem = SubsystemName.Get("LiveTranscriptionStreaming");

    public static readonly SubsystemName TranscriptionTracking = SubsystemName.Get("TranscriptionTracking");
    public static readonly SubsystemName TranscriptionTimeLogging = SubsystemName.Get("TranscriptionTimeLogging");
    public static readonly SubsystemName TranscriptionCreation = SubsystemName.Get("TranscriptionCreation");
    public static readonly SubsystemName ProjectStatusMonitor = SubsystemName.Get("ProjectStatusMonitor");
    public static readonly SubsystemName VoiceprintAggregation = SubsystemName.Get("VoiceprintAggregation");
    public static readonly SubsystemName TranscriptionQueueTrackingSubsystem = SubsystemName.Get("TranscriptionQueueTracking");
    public static readonly SubsystemName LowQualityAudioSubsystem = SubsystemName.Get("LowQualityAudio");
    public static readonly SubsystemName SceneDetectionSubsystem = SubsystemName.Get("SceneDetection");

    public static readonly SubsystemName TranscodingGroup = SubsystemName.Get("Transcoding");
    public static readonly SubsystemName TranscribingGroup = SubsystemName.Get("Transcribing");
    public static readonly SubsystemName RecognitionGroup = SubsystemName.Get("Recognition");
    public static readonly SubsystemName PostprocessingGroup = SubsystemName.Get("Posprocessing");
    public static readonly SubsystemName PackagingGroup = SubsystemName.Get("Packaging");
    public static readonly SubsystemName TextCreationGroup = SubsystemName.Get("TextCreation");
    public static readonly SubsystemName ChainControl = SubsystemName.Get("ChainControl");

    // Virtual subsystems
    public static readonly SubsystemName CreditReservation = SubsystemName.Get("CreditReservation");

    public static readonly SubsystemName ProjectUpdates = SubsystemName.Get("ProjectUpdates");
}
