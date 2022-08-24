using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;
using Beey.DataExchangeModel.Messaging;

using static Beey.DataExchangeModel.Messaging.KnownSubsystems;

namespace Beey.DataExchangeModel.Serialization.JsonConverters;

public class MessageJsonConverterWithTypeDiscriminator : JsonConverter<Message>
{

    public override bool CanConvert(Type typeToConvert) =>
        typeof(Message).IsAssignableFrom(typeToConvert);

    public override Message? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        MessageType messageType;
        string subsystem;
        JsonObject jMessage = (JsonObject)(JsonNode.Parse(ref reader) ?? throw new JsonException());

        if (!(jMessage.TryGetPropertyValue(nameof(Message.Type), out var jType)
            && jType is JsonValue vType
            && vType.TryGetValue<string>(out var sType)
            && Enum.TryParse<MessageType>(sType, out messageType)
            ))
            throw new JsonException();

        if (!(jMessage.TryGetPropertyValue(nameof(Message.Subsystem), out var jSubsystem)
            && jSubsystem is JsonValue vSubsystem
            && vSubsystem.TryGetValue<string>(out subsystem)
            && subsystem != null)
            )
            throw new JsonException();

        return messageType switch
        {
            MessageType.Started => DiscriminateStartedMessage(jMessage, options, subsystem),
            MessageType.Progress => DiscriminateProgressMessage(jMessage, options, subsystem),
            MessageType.Failed => DiscriminateFailedMessage(jMessage, options, subsystem),
            MessageType.Completed => DiscriminateCompletedMessage(jMessage, options, subsystem),
            MessageType.Panic => JsonSerializer.Deserialize<PanicMessage>(jMessage, options),

            MessageType.ChainStatus => JsonSerializer.Deserialize<ChainControl.Status>(jMessage, options),
            MessageType.ChainCommand => JsonSerializer.Deserialize<ChainControl.Command>(jMessage, options),
            _ => throw new JsonException($"Unknown messageType: {messageType}"),
        };
    }

    public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        switch (value.Type)
        {
            case MessageType.Started:
                DiscriminateStartedMessage(writer, value, options);
                return;
            case MessageType.Progress:
                DiscriminateProgressMessage(writer, value, options);
                return;
            case MessageType.Failed:
                DiscriminateFailedMessage(writer, value, options);
                return;
            case MessageType.Completed:
                DiscriminateCompletedMessage(writer, value, options);
                return;
            case MessageType.ChainStatus:
                JsonSerializer.Serialize(writer, (ChainControl.Status)value, ChainControl.ChainControlSerializerContext.Default.Status);
                return;
            case MessageType.ChainCommand:
                JsonSerializer.Serialize(writer, (ChainControl.Command)value, ChainControl.ChainControlSerializerContext.Default.Command);
                return;
            case MessageType.Panic:
                JsonSerializer.Serialize(writer, (PanicMessage)value, ChainControl.ChainControlSerializerContext.Default.PanicMessage);
                return;
        }
        throw new NotImplementedException($"Unknown message {value}");
    }

    static void DiscriminateStartedMessage(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        var subsystem = value.Subsystem;
        if (subsystem == Diarization.Name)
        {
            JsonSerializer.Serialize(writer, (Diarization.Started)value, Diarization.DiarizationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == VoiceprintAggregation.Name)
        {
            JsonSerializer.Serialize(writer, (VoiceprintAggregation.Started)value, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == Upload.Name)
        {
            JsonSerializer.Serialize(writer, (Upload.Started)value, Upload.UploadSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscriptionTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTracking.Started)value, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscriptionTimeLogging.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTimeLogging.Started)value, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscriptionCreation.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionCreation.Started)value, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == MediaFilePackaging.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFilePackaging.Started)value, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == CreditReservation.Name)
        {
            JsonSerializer.Serialize(writer, (CreditReservation.Started)value, CreditReservation.CreditReservationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == MediaFileIndexing.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFileIndexing.Started)value, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == MediaIdentification.Name)
        {
            JsonSerializer.Serialize(writer, (MediaIdentification.Started)value, MediaIdentification.MediaIdentificationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == ProjectStatusMonitor.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectStatusMonitor.Started)value, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == Recognition.Name)
        {
            JsonSerializer.Serialize(writer, (Recognition.Started)value, Recognition.RecognitionSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == SpeakerId.Name)
        {
            JsonSerializer.Serialize(writer, (SpeakerId.Started)value, SpeakerId.SpeakerIdentificationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == Spp.Name)
        {
            JsonSerializer.Serialize(writer, (Spp.Started)value, Spp.SppSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscodingVideo.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingVideo.Started)value, TranscodingVideo.TranscodingVideoSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscodingAudio.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingAudio.Started)value, TranscodingAudio.TranscodingAudioSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == ChainControl.Name)
        {
            JsonSerializer.Serialize(writer, (ChainControl.Started)value, ChainControl.ChainControlSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscriptionQueueTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionQueueTracking.Started)value, TranscriptionQueueTracking.TranscriptionQueueTrackingSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == LowQualityAudio.Name)
        {
            JsonSerializer.Serialize(writer, (LowQualityAudio.Started)value, LowQualityAudio.LowQualityAudioSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == SceneDetection.Name)
        {
            JsonSerializer.Serialize(writer, (SceneDetection.Started)value, SceneDetection.SceneDetectionSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == RawDiarization.Name)
        {
            JsonSerializer.Serialize(writer, (RawDiarization.Started)value, RawDiarization.RawDiarizationSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == RawRecognition.Name)
        {
            JsonSerializer.Serialize(writer, (RawRecognition.Started)value, RawRecognition.RawRecognitionSerializerContext.Default.Started);
            return;
        }
        else if (subsystem == TranscriptionStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionStreaming.Started)value, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Started);
            return;
        }

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static void DiscriminateCompletedMessage(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        var subsystem = value.Subsystem;
        if (subsystem == Diarization.Name)
        {
            JsonSerializer.Serialize(writer, (Diarization.Completed)value, Diarization.DiarizationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == VoiceprintAggregation.Name)
        {
            JsonSerializer.Serialize(writer, (VoiceprintAggregation.Completed)value, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == Upload.Name)
        {
            JsonSerializer.Serialize(writer, (Upload.Completed)value, Upload.UploadSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscriptionTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTracking.Completed)value, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscriptionTimeLogging.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTimeLogging.Completed)value, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscriptionCreation.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionCreation.Completed)value, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == MediaFilePackaging.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFilePackaging.Completed)value, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == CreditReservation.Name)
        {
            JsonSerializer.Serialize(writer, (CreditReservation.Completed)value, CreditReservation.CreditReservationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == MediaFileIndexing.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFileIndexing.Completed)value, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == MediaIdentification.Name)
        {
            JsonSerializer.Serialize(writer, (MediaIdentification.Completed)value, MediaIdentification.MediaIdentificationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == ProjectStatusMonitor.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectStatusMonitor.Completed)value, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == Recognition.Name)
        {
            JsonSerializer.Serialize(writer, (Recognition.Completed)value, Recognition.RecognitionSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == SpeakerId.Name)
        {
            JsonSerializer.Serialize(writer, (SpeakerId.Completed)value, SpeakerId.SpeakerIdentificationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == Spp.Name)
        {
            JsonSerializer.Serialize(writer, (Spp.Completed)value, Spp.SppSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscodingVideo.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingVideo.Completed)value, TranscodingVideo.TranscodingVideoSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscodingAudio.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingAudio.Completed)value, TranscodingAudio.TranscodingAudioSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == ChainControl.Name)
        {
            JsonSerializer.Serialize(writer, (ChainControl.Completed)value, ChainControl.ChainControlSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscriptionQueueTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionQueueTracking.Completed)value, TranscriptionQueueTracking.TranscriptionQueueTrackingSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == LowQualityAudio.Name)
        {
            JsonSerializer.Serialize(writer, (LowQualityAudio.Completed)value, LowQualityAudio.LowQualityAudioSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == SceneDetection.Name)
        {
            JsonSerializer.Serialize(writer, (SceneDetection.Completed)value, SceneDetection.SceneDetectionSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == RawDiarization.Name)
        {
            JsonSerializer.Serialize(writer, (RawDiarization.Completed)value, RawDiarization.RawDiarizationSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == RawRecognition.Name)
        {
            JsonSerializer.Serialize(writer, (RawRecognition.Completed)value, RawRecognition.RawRecognitionSerializerContext.Default.Completed);
            return;
        }
        else if (subsystem == TranscriptionStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionStreaming.Completed)value, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Completed);
            return;
        }

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }


    static void DiscriminateFailedMessage(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        var subsystem = value.Subsystem;
        if (value.GetType() == typeof(FailedMessage))
        {
            JsonSerializer.Serialize(writer, (FailedMessage)value, ChainControl.ChainControlSerializerContext.Default.FailedMessage);
            return;
        }
        else if (subsystem == Diarization.Name)
        {
            JsonSerializer.Serialize(writer, (Diarization.Failed)value, Diarization.DiarizationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == VoiceprintAggregation.Name)
        {
            JsonSerializer.Serialize(writer, (VoiceprintAggregation.Failed)value, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == Upload.Name)
        {
            JsonSerializer.Serialize(writer, (Upload.Failed)value, Upload.UploadSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscriptionTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTracking.Failed)value, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscriptionTimeLogging.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTimeLogging.Failed)value, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscriptionCreation.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionCreation.Failed)value, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == MediaFilePackaging.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFilePackaging.Failed)value, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == CreditReservation.Name)
        {
            JsonSerializer.Serialize(writer, (CreditReservation.Failed)value, CreditReservation.CreditReservationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == MediaFileIndexing.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFileIndexing.Failed)value, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == MediaIdentification.Name)
        {
            JsonSerializer.Serialize(writer, (MediaIdentification.Failed)value, MediaIdentification.MediaIdentificationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == ProjectStatusMonitor.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectStatusMonitor.Failed)value, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == Recognition.Name)
        {
            JsonSerializer.Serialize(writer, (Recognition.Failed)value, Recognition.RecognitionSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == SpeakerId.Name)
        {
            JsonSerializer.Serialize(writer, (SpeakerId.Failed)value, SpeakerId.SpeakerIdentificationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == Spp.Name)
        {
            JsonSerializer.Serialize(writer, (Spp.Failed)value, Spp.SppSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscodingVideo.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingVideo.Failed)value, TranscodingVideo.TranscodingVideoSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscodingAudio.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingAudio.Failed)value, TranscodingAudio.TranscodingAudioSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == ChainControl.Name)
        {
            JsonSerializer.Serialize(writer, (ChainControl.Failed)value, ChainControl.ChainControlSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == LowQualityAudio.Name)
        {
            JsonSerializer.Serialize(writer, (LowQualityAudio.Failed)value, LowQualityAudio.LowQualityAudioSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == SceneDetection.Name)
        {
            JsonSerializer.Serialize(writer, (SceneDetection.Failed)value, SceneDetection.SceneDetectionSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == RawDiarization.Name)
        {
            JsonSerializer.Serialize(writer, (RawDiarization.Failed)value, RawDiarization.RawDiarizationSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == RawRecognition.Name)
        {
            JsonSerializer.Serialize(writer, (RawRecognition.Failed)value, RawRecognition.RawRecognitionSerializerContext.Default.Failed);
            return;
        }
        else if (subsystem == TranscriptionStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionStreaming.Failed)value, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Failed);
            return;
        }


        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static void DiscriminateProgressMessage(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
    {
        var subsystem = value.Subsystem;
        if (subsystem == Diarization.Name)
        {
            JsonSerializer.Serialize(writer, (Diarization.Progress)value, Diarization.DiarizationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == VoiceprintAggregation.Name)
        {
            JsonSerializer.Serialize(writer, (VoiceprintAggregation.Progress)value, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Upload.Name)
        {
            JsonSerializer.Serialize(writer, (Upload.Progress)value, Upload.UploadSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionTracking.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTracking.Progress)value, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionTimeLogging.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionTimeLogging.Progress)value, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionCreation.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionCreation.Progress)value, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaFilePackaging.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFilePackaging.Progress)value, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == CreditReservation.Name)
        {
            JsonSerializer.Serialize(writer, (CreditReservation.Progress)value, CreditReservation.CreditReservationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaFileIndexing.Name)
        {
            JsonSerializer.Serialize(writer, (MediaFileIndexing.Progress)value, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == MediaIdentification.Name)
        {
            JsonSerializer.Serialize(writer, (MediaIdentification.Progress)value, MediaIdentification.MediaIdentificationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == ProjectStatusMonitor.Name)
        {
            JsonSerializer.Serialize(writer, (ProjectStatusMonitor.Progress)value, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Recognition.Name)
        {
            JsonSerializer.Serialize(writer, (Recognition.Progress)value, Recognition.RecognitionSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == SpeakerId.Name)
        {
            JsonSerializer.Serialize(writer, (SpeakerId.Progress)value, SpeakerId.SpeakerIdentificationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == Spp.Name)
        {
            JsonSerializer.Serialize(writer, (Spp.Progress)value, Spp.SppSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscodingVideo.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingVideo.Progress)value, TranscodingVideo.TranscodingVideoSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscodingAudio.Name)
        {
            JsonSerializer.Serialize(writer, (TranscodingAudio.Progress)value, TranscodingAudio.TranscodingAudioSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == RawDiarization.Name)
        {
            JsonSerializer.Serialize(writer, (RawDiarization.Progress)value, RawDiarization.RawDiarizationSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == RawRecognition.Name)
        {
            JsonSerializer.Serialize(writer, (RawRecognition.Progress)value, RawRecognition.RawRecognitionSerializerContext.Default.Progress);
            return;
        }
        else if (subsystem == TranscriptionStreaming.Name)
        {
            JsonSerializer.Serialize(writer, (TranscriptionStreaming.Progress)value, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Progress);
            return;
        }

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }



    static StartedMessage? DiscriminateStartedMessage(JsonObject jMessage, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize<Diarization.Started>(jMessage);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize<VoiceprintAggregation.Started>(jMessage);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize<Upload.Started>(jMessage);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionTracking.Started>(jMessage);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize<TranscriptionTimeLogging.Started>(jMessage);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize<TranscriptionCreation.Started>(jMessage);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize<MediaFilePackaging.Started>(jMessage);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize<CreditReservation.Started>(jMessage);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize<MediaFileIndexing.Started>(jMessage);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize<MediaIdentification.Started>(jMessage);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize<ProjectStatusMonitor.Started>(jMessage);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize<Recognition.Started>(jMessage);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize<SpeakerId.Started>(jMessage);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize<Spp.Started>(jMessage);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize<TranscodingVideo.Started>(jMessage);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize<TranscodingAudio.Started>(jMessage);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize<ChainControl.Started>(jMessage);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize<LowQualityAudio.Started>(jMessage);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize<SceneDetection.Started>(jMessage);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize<RawRecognition.Started>(jMessage);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize<RawDiarization.Started>(jMessage);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize<TranscriptionStreaming.Started>(jMessage);
        if (subsystem == TranscriptionQueueTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionQueueTracking.Started>(jMessage);

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static CompletedMessage? DiscriminateCompletedMessage(JsonObject jMessage, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize<Diarization.Completed>(jMessage);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize<VoiceprintAggregation.Completed>(jMessage);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize<Upload.Completed>(jMessage);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionTracking.Completed>(jMessage);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize<TranscriptionTimeLogging.Completed>(jMessage);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize<TranscriptionCreation.Completed>(jMessage);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize<MediaFilePackaging.Completed>(jMessage);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize<CreditReservation.Completed>(jMessage);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize<MediaFileIndexing.Completed>(jMessage);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize<MediaIdentification.Completed>(jMessage);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize<ProjectStatusMonitor.Completed>(jMessage);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize<Recognition.Completed>(jMessage);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize<SpeakerId.Completed>(jMessage);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize<Spp.Completed>(jMessage);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize<TranscodingVideo.Completed>(jMessage);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize<TranscodingAudio.Completed>(jMessage);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize<ChainControl.Completed>(jMessage);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize<LowQualityAudio.Completed>(jMessage);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize<SceneDetection.Completed>(jMessage);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize<RawRecognition.Completed>(jMessage);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize<RawDiarization.Completed>(jMessage);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize<TranscriptionStreaming.Completed>(jMessage);
        if (subsystem == TranscriptionQueueTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionQueueTracking.Completed>(jMessage);

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }


    static FailedMessage? DiscriminateFailedMessage(JsonObject jMessage, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize<Diarization.Failed>(jMessage);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize<VoiceprintAggregation.Failed>(jMessage)!;
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize<Upload.Failed>(jMessage);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionTracking.Failed>(jMessage);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize<TranscriptionTimeLogging.Failed>(jMessage);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize<TranscriptionCreation.Failed>(jMessage);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize<MediaFilePackaging.Failed>(jMessage);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize<CreditReservation.Failed>(jMessage);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize<MediaFileIndexing.Failed>(jMessage);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize<MediaIdentification.Failed>(jMessage);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize<ProjectStatusMonitor.Failed>(jMessage);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize<Recognition.Failed>(jMessage);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize<SpeakerId.Failed>(jMessage);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize<Spp.Failed>(jMessage);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize<TranscodingVideo.Failed>(jMessage);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize<TranscodingAudio.Failed>(jMessage);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize<ChainControl.Failed>(jMessage);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize<LowQualityAudio.Failed>(jMessage);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize<SceneDetection.Failed>(jMessage);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize<RawRecognition.Failed>(jMessage);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize<RawDiarization.Failed>(jMessage);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize<TranscriptionStreaming.Failed>(jMessage);
        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static ProgressMessage? DiscriminateProgressMessage(JsonObject jMessage, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize<Diarization.Progress>(jMessage);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize<VoiceprintAggregation.Progress>(jMessage);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize<Upload.Progress>(jMessage);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize<TranscriptionTracking.Progress>(jMessage);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize<TranscriptionTimeLogging.Progress>(jMessage);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize<TranscriptionCreation.Progress>(jMessage);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize<MediaFilePackaging.Progress>(jMessage);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize<CreditReservation.Progress>(jMessage);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize<MediaFileIndexing.Progress>(jMessage);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize<MediaIdentification.Progress>(jMessage);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize<ProjectStatusMonitor.Progress>(jMessage);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize<Recognition.Progress>(jMessage);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize<SpeakerId.Progress>(jMessage);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize<Spp.Progress>(jMessage);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize<TranscodingVideo.Progress>(jMessage);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize<TranscodingAudio.Progress>(jMessage);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize<RawRecognition.Progress>(jMessage);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize<RawDiarization.Progress>(jMessage);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize<TranscriptionStreaming.Progress>(jMessage);
        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }
}
