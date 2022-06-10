using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Messaging.Chain;

namespace Beey.DataExchangeModel.Messaging;
public static class KnownSubsystems
{
    public static class Diarization
    {
        public static string Name => KnownSubsystemNames.DiarizationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class VoiceprintAggregation
    {
        public static string Name => KnownSubsystemNames.VoiceprintAggregation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);

    }
    public static class Upload
    {
        public static string Name => KnownSubsystemNames.UploadSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class TranscriptionTracking
    {
        public static string Name => KnownSubsystemNames.TranscriptionTracking;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class TranscriptionTimeLogging
    {
        public static string Name => KnownSubsystemNames.TranscriptionTimeLogging;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class TranscriptionCreation
    {
        public static string Name => KnownSubsystemNames.TranscriptionCreation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class MediaFilePackaging
    {
        public static string Name => KnownSubsystemNames.MediaFilePackagingSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class CreditReservation
    {
        public static string Name => KnownSubsystemNames.CreditReservation;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class MediaFileIndexing
    {
        public static string Name => KnownSubsystemNames.MediaFileIndexingSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class MediaIdentification
    {
        public static string Name => KnownSubsystemNames.MediaIdentificationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class ProjectStatusMonitor
    {
        public static string Name => KnownSubsystemNames.ProjectStatusMonitor;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class Recognition
    {
        public static string Name => KnownSubsystemNames.RecognitionSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class SpeakerIdentification
    {
        public static string Name => KnownSubsystemNames.SpeakerIdentificationSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class Spp
    {
        public static string Name => KnownSubsystemNames.SppSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class TranscodingVideo
    {
        public static string Name => KnownSubsystemNames.TranscodingVideoSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class TranscodingAudio
    {
        public static string Name => KnownSubsystemNames.TranscodingAudioSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
    }
    public static class Chain
    {
        public static string Name => KnownSubsystemNames.ChainSubsystem;
        public sealed record Started(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : StartedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record Progress(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, JsonData Data) : ProgressMessage(Id, Index, ProjectId, Name, Sent, Data);
        public sealed record Failed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, string Reason) : FailedMessage(Id, Index, ProjectId, Name, Sent, Reason);
        public sealed record Completed(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent) : CompletedMessage(Id, Index, ProjectId, Name, Sent);
        public sealed record class ChainStatusMessage(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, NodeStatus? Status) : Backend.Messaging.Chain.ChainStatusMessage(Id, Index, ProjectId, Sent, Status);
        public sealed record class ChainCommandMessage(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, ChainCommand Command) : Backend.Messaging.Chain.ChainCommandMessage(Id, Index, ProjectId, Sent, Command);
    }
}
