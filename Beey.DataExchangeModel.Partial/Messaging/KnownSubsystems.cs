using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystems
{
    public static readonly string Diarization = "Diarization";
    public static readonly string VoiceprintAggregation = "VoiceprintAggregation";
    public static readonly string Upload;
    public static readonly string TranscriptionTracking;
    public static readonly string TranscriptionTimeLogging;
    public static readonly string TranscriptionCreation;
    public static readonly string MediaFilePackaging;
    public static readonly string CreditReservation;
    public static readonly string MediaFileIndexing;
    public static readonly string MediaIdentification;
    public static readonly string ProjectStatusMonitor;
    public static readonly string Recognition;
    public static readonly string SpeakerIdentification;
    public static readonly string Spp;
    public static readonly string TranscodingVideo;

    public static string TranscodingAudio { get; set; }
}
