using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystemNames
{
    public const string UploadSubsystem = "UploadSubsystem";
    public const string MediaIdentificationSubsystem = "MediaIdentificationSubsystem";
    public const string TranscodingVideoSubsystem = "TranscodingVideoSubsystem";
    public const string TranscodingAudioSubsystem = "TranscodingAudioSubsystem";
    public const string MediaFileIndexingSubsystem = "MediaFileIndexingSubsystem";
    public const string MediaFilePackagingSubsystem = "MediaFilePackagingSubsystem";
    public const string RecognitionSubsystem = "RecognitionSubsystem";
    public const string DiarizationSubsystem = "DiarizationSubsystem";
    public const string SpeakerIdentificationSubsystem = "SpeakerIdentificationSubsystem";
    public const string SppSubsystem = "SppSubsystem";
    public const string TranscriptionTracking = "TranscriptionTrackingSubsystem";
    public const string TranscriptionTimeLogging = "TranscriptionTimeLoggingSubsystem";
    public const string TranscriptionCreation = "TranscriptionCreationSubsystem";
    public const string CreditReservation = "CreditReservationSubsystem";
    public const string ProjectStatusMonitor = "ProjectStatusMonitorSubsystem";
    public const string VoiceprintAggregation = "VoiceprintAggregationSubsystem";


    public const string TranscodingGroup = "Transcoding";
    public const string TranscribingGroup = "Transcribing";
    public const string RecognitionGroup = "Recognition";
    public const string PostprocessingGroup = "Posprocessing";
    public const string TextCreationGroup = "TextCreation";
    public const string ChainSubsystem = "ChainControl";
}
