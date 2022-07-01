﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public const string SpeakerIdentificationSubsystem = "SpeakerIdentification";
    public const string SppSubsystem = "Spp";
    public const string TranscriptionTracking = "TranscriptionTracking";
    public const string TranscriptionTimeLogging = "TranscriptionTimeLogging";
    public const string TranscriptionCreation = "TranscriptionCreation";
    public const string CreditReservation = "CreditReservation";
    public const string ProjectStatusMonitor = "ProjectStatusMonitor";
    public const string VoiceprintAggregation = "VoiceprintAggregation";
    public const string TranscriptionQueueTrackingSubsystem = "TranscriptionQueueTracking";


    public const string TranscodingGroup = "Transcoding";
    public const string TranscribingGroup = "Transcribing";
    public const string RecognitionGroup = "Recognition";
    public const string PostprocessingGroup = "Posprocessing";
    public const string TextCreationGroup = "TextCreation";
    public const string ChainControl = "ChainControl";
}
