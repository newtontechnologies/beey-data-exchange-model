using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Messaging.Chain;

namespace Beey.DataExchangeModel.Messaging;



public static partial class KnownSubsystems
{
    public static partial class Diarization
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class DiarizationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.DiarizationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class VoiceprintAggregation
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class VoiceprintAggregationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.VoiceprintAggregation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);

    }
    public static partial class Upload
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class UploadSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.UploadSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class TranscriptionTracking
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscriptionTrackingSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.TranscriptionTracking;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class TranscriptionTimeLogging
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscriptionTimeLoggingSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.TranscriptionTimeLogging;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class TranscriptionCreation
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscriptionCreationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.TranscriptionCreation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class MediaFilePackaging
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class MediaFilePackagingSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.MediaFilePackagingSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class CreditReservation
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class CreditReservationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.CreditReservation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class MediaFileIndexing
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class MediaFileIndexingSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.MediaFileIndexingSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class MediaIdentification
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class MediaIdentificationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.MediaIdentificationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class ProjectStatusMonitor
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class ProjectStatusMonitorSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.ProjectStatusMonitor;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class Recognition
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class RecognitionSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.RecognitionSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class SpeakerIdentification
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class SpeakerIdentificationSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.SpeakerIdentificationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class Spp
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class SppSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.SppSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class TranscodingVideo
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscodingVideoSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.TranscodingVideoSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static partial class TranscodingAudio
    {
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Progress))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscodingAudioSerializerContext : JsonSerializerContext { };
        public static string Name => KnownSubsystemNames.TranscodingAudioSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonNode Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }

    public static partial class TranscriptionQueueTracking
    {

        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Completed))]
        public partial class TranscriptionQueueTrackingSerializerContext : JsonSerializerContext { };

        public static string Name => KnownSubsystemNames.TranscriptionQueueTrackingSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }

    public static partial class ChainControl
    {

        [JsonSerializable(typeof(PanicMessage))]
        [JsonSerializable(typeof(Started))]
        [JsonSerializable(typeof(Failed))]
        [JsonSerializable(typeof(Completed))]
        [JsonSerializable(typeof(Status))]
        [JsonSerializable(typeof(Command))]
        public partial class ChainControlSerializerContext : JsonSerializerContext { }

        public static string Name => KnownSubsystemNames.ChainControl;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Status(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, NodeStatus? Status) : ChainStatusMessage(Id, Index, ProjectId, Sent, Status);
        public sealed record Command(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, ChainCommand Command) : ChainCommandMessage(Id, Index, ProjectId, Sent, Command);
    }
}
