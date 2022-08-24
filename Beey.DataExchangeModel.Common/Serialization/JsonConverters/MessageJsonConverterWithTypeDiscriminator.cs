using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        reader.Read();
        if (reader.TokenType != JsonTokenType.PropertyName)
            throw new JsonException();

        string? propertyName = reader.GetString();
        if (propertyName != nameof(Message.Type))
            throw new JsonException();

        reader.Read();
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException();


        if (!Enum.TryParse<MessageType>(reader.GetString(), out var messageType))
            throw new JsonException();

        reader.Read();
        if (reader.TokenType != JsonTokenType.PropertyName)
            throw new JsonException();

        propertyName = reader.GetString();
        if (propertyName != nameof(Message.Subsystem))
            throw new JsonException();

        reader.Read();
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException();

        var subsystem = reader.GetString()!;

        return messageType switch
        {
            MessageType.Started => DiscriminateStartedMessage(ref reader, options, subsystem),
            MessageType.Progress => DiscriminateProgressMessage(ref reader, options, subsystem),
            MessageType.Failed => DiscriminateFailedMessage(ref reader, options, subsystem),
            MessageType.Completed => DiscriminateCompletedMessage(ref reader, options, subsystem),
            MessageType.Panic => JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.PanicMessage),

            MessageType.ChainStatus => JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.Status),
            MessageType.ChainCommand => JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.Command),
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



    static StartedMessage? DiscriminateStartedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize(ref reader, Diarization.DiarizationSerializerContext.Default.Started);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize(ref reader, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Started);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize(ref reader, Upload.UploadSerializerContext.Default.Started);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Started);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Started);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Started);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Started);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize(ref reader, CreditReservation.CreditReservationSerializerContext.Default.Started);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Started);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize(ref reader, MediaIdentification.MediaIdentificationSerializerContext.Default.Started);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize(ref reader, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Started);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize(ref reader, Recognition.RecognitionSerializerContext.Default.Started);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize(ref reader, SpeakerId.SpeakerIdentificationSerializerContext.Default.Started);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize(ref reader, Spp.SppSerializerContext.Default.Started);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingVideo.TranscodingVideoSerializerContext.Default.Started);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingAudio.TranscodingAudioSerializerContext.Default.Started);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.Started);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize(ref reader, LowQualityAudio.LowQualityAudioSerializerContext.Default.Started);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize(ref reader, SceneDetection.SceneDetectionSerializerContext.Default.Started);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize(ref reader, RawRecognition.RawRecognitionSerializerContext.Default.Started);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize(ref reader, RawDiarization.RawDiarizationSerializerContext.Default.Started);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Started);
        if (subsystem == TranscriptionQueueTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionQueueTracking.TranscriptionQueueTrackingSerializerContext.Default.Started);

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static CompletedMessage? DiscriminateCompletedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize(ref reader, Diarization.DiarizationSerializerContext.Default.Completed);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize(ref reader, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Completed);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize(ref reader, Upload.UploadSerializerContext.Default.Completed);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Completed);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Completed);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Completed);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Completed);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize(ref reader, CreditReservation.CreditReservationSerializerContext.Default.Completed);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Completed);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize(ref reader, MediaIdentification.MediaIdentificationSerializerContext.Default.Completed);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize(ref reader, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Completed);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize(ref reader, Recognition.RecognitionSerializerContext.Default.Completed);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize(ref reader, SpeakerId.SpeakerIdentificationSerializerContext.Default.Completed);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize(ref reader, Spp.SppSerializerContext.Default.Completed);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingVideo.TranscodingVideoSerializerContext.Default.Completed);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingAudio.TranscodingAudioSerializerContext.Default.Completed);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.Completed);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize(ref reader, LowQualityAudio.LowQualityAudioSerializerContext.Default.Completed);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize(ref reader, SceneDetection.SceneDetectionSerializerContext.Default.Completed);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize(ref reader, RawRecognition.RawRecognitionSerializerContext.Default.Completed);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize(ref reader, RawDiarization.RawDiarizationSerializerContext.Default.Completed);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Completed);
        if (subsystem == TranscriptionQueueTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionQueueTracking.TranscriptionQueueTrackingSerializerContext.Default.Completed);

        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }


    static FailedMessage? DiscriminateFailedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize(ref reader, Diarization.DiarizationSerializerContext.Default.Failed);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize(ref reader, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Failed)!;
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize(ref reader, Upload.UploadSerializerContext.Default.Failed);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Failed);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Failed);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Failed);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Failed);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize(ref reader, CreditReservation.CreditReservationSerializerContext.Default.Failed);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Failed);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize(ref reader, MediaIdentification.MediaIdentificationSerializerContext.Default.Failed);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize(ref reader, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Failed);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize(ref reader, Recognition.RecognitionSerializerContext.Default.Failed);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize(ref reader, SpeakerId.SpeakerIdentificationSerializerContext.Default.Failed);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize(ref reader, Spp.SppSerializerContext.Default.Failed);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingVideo.TranscodingVideoSerializerContext.Default.Failed);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingAudio.TranscodingAudioSerializerContext.Default.Failed);
        if (subsystem == ChainControl.Name)
            return JsonSerializer.Deserialize(ref reader, ChainControl.ChainControlSerializerContext.Default.Failed);
        if (subsystem == LowQualityAudio.Name)
            return JsonSerializer.Deserialize(ref reader, LowQualityAudio.LowQualityAudioSerializerContext.Default.Failed);
        if (subsystem == SceneDetection.Name)
            return JsonSerializer.Deserialize(ref reader, SceneDetection.SceneDetectionSerializerContext.Default.Failed);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize(ref reader, RawRecognition.RawRecognitionSerializerContext.Default.Failed);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize(ref reader, RawDiarization.RawDiarizationSerializerContext.Default.Failed);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Failed);
        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

    static ProgressMessage? DiscriminateProgressMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
    {
        if (subsystem == Diarization.Name)
            return JsonSerializer.Deserialize(ref reader, Diarization.DiarizationSerializerContext.Default.Progress);
        if (subsystem == VoiceprintAggregation.Name)
            return JsonSerializer.Deserialize(ref reader, VoiceprintAggregation.VoiceprintAggregationSerializerContext.Default.Progress);
        if (subsystem == Upload.Name)
            return JsonSerializer.Deserialize(ref reader, Upload.UploadSerializerContext.Default.Progress);
        if (subsystem == TranscriptionTracking.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTracking.TranscriptionTrackingSerializerContext.Default.Progress);
        if (subsystem == TranscriptionTimeLogging.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionTimeLogging.TranscriptionTimeLoggingSerializerContext.Default.Progress);
        if (subsystem == TranscriptionCreation.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionCreation.TranscriptionCreationSerializerContext.Default.Progress);
        if (subsystem == MediaFilePackaging.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFilePackaging.MediaFilePackagingSerializerContext.Default.Progress);
        if (subsystem == CreditReservation.Name)
            return JsonSerializer.Deserialize(ref reader, CreditReservation.CreditReservationSerializerContext.Default.Progress);
        if (subsystem == MediaFileIndexing.Name)
            return JsonSerializer.Deserialize(ref reader, MediaFileIndexing.MediaFileIndexingSerializerContext.Default.Progress);
        if (subsystem == MediaIdentification.Name)
            return JsonSerializer.Deserialize(ref reader, MediaIdentification.MediaIdentificationSerializerContext.Default.Progress);
        if (subsystem == ProjectStatusMonitor.Name)
            return JsonSerializer.Deserialize(ref reader, ProjectStatusMonitor.ProjectStatusMonitorSerializerContext.Default.Progress);
        if (subsystem == Recognition.Name)
            return JsonSerializer.Deserialize(ref reader, Recognition.RecognitionSerializerContext.Default.Progress);
        if (subsystem == SpeakerId.Name)
            return JsonSerializer.Deserialize(ref reader, SpeakerId.SpeakerIdentificationSerializerContext.Default.Progress);
        if (subsystem == Spp.Name)
            return JsonSerializer.Deserialize(ref reader, Spp.SppSerializerContext.Default.Progress);
        if (subsystem == TranscodingVideo.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingVideo.TranscodingVideoSerializerContext.Default.Progress);
        if (subsystem == TranscodingAudio.Name)
            return JsonSerializer.Deserialize(ref reader, TranscodingAudio.TranscodingAudioSerializerContext.Default.Progress);
        if (subsystem == RawRecognition.Name)
            return JsonSerializer.Deserialize(ref reader, RawRecognition.RawRecognitionSerializerContext.Default.Progress);
        if (subsystem == RawDiarization.Name)
            return JsonSerializer.Deserialize(ref reader, RawDiarization.RawDiarizationSerializerContext.Default.Progress);
        if (subsystem == TranscriptionStreaming.Name)
            return JsonSerializer.Deserialize(ref reader, TranscriptionStreaming.TranscriptionStreamingSerializerContext.Default.Progress);
        throw new NotImplementedException($"Unknown subsystem {subsystem}");
    }

}
