using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;
using Beey.DataExchangeModel.Messaging;

using static Beey.DataExchangeModel.Messaging.KnownSubsystems;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    public class MessageJsonConverterWithTypeDiscriminator : JsonConverter<Message>
    {

        public override bool CanConvert(Type typeToConvert) =>
            typeof(Message).IsAssignableFrom(typeToConvert);

        public override Message Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
                MessageType.Panic => JsonSerializer.Deserialize<PanicMessage>(ref reader, options)!,

                MessageType.ChainStatus => JsonSerializer.Deserialize<ChainControl.Status>(ref reader, options)!,
                MessageType.ChainCommand => JsonSerializer.Deserialize<ChainControl.Command>(ref reader, options)!,
                _ => throw new JsonException($"Unknown messageType: {messageType}"),
            };
        }

        public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
        {
            var o2 = new JsonSerializerOptions(options);
            var disc = o2.Converters.First(c => c is MessageJsonConverterWithTypeDiscriminator);
            o2.Converters.Remove(disc);
            JsonSerializer.Serialize(writer, value, value.GetType(), o2);
        }

        static StartedMessage DiscriminateStartedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == Diarization.Name)
                return JsonSerializer.Deserialize<Diarization.Started>(ref reader, options)!;
            if (subsystem == VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<VoiceprintAggregation.Started>(ref reader, options)!;
            if (subsystem == Upload.Name)
                return JsonSerializer.Deserialize<Upload.Started>(ref reader, options)!;
            if (subsystem == TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<TranscriptionTracking.Started>(ref reader, options)!;
            if (subsystem == TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<TranscriptionTimeLogging.Started>(ref reader, options)!;
            if (subsystem == TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<TranscriptionCreation.Started>(ref reader, options)!;
            if (subsystem == MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<MediaFilePackaging.Started>(ref reader, options)!;
            if (subsystem == CreditReservation.Name)
                return JsonSerializer.Deserialize<CreditReservation.Started>(ref reader, options)!;
            if (subsystem == MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<MediaFileIndexing.Started>(ref reader, options)!;
            if (subsystem == MediaIdentification.Name)
                return JsonSerializer.Deserialize<MediaIdentification.Started>(ref reader, options)!;
            if (subsystem == ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<ProjectStatusMonitor.Started>(ref reader, options)!;
            if (subsystem == Recognition.Name)
                return JsonSerializer.Deserialize<Recognition.Started>(ref reader, options)!;
            if (subsystem == SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<SpeakerIdentification.Started>(ref reader, options)!;
            if (subsystem == Spp.Name)
                return JsonSerializer.Deserialize<Spp.Started>(ref reader, options)!;
            if (subsystem == TranscodingVideo.Name)
                return JsonSerializer.Deserialize<TranscodingVideo.Started>(ref reader, options)!;
            if (subsystem == TranscodingAudio.Name)
                return JsonSerializer.Deserialize<TranscodingAudio.Started>(ref reader, options)!;
            if (subsystem == ChainControl.Name)
                return JsonSerializer.Deserialize<ChainControl.Started>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static CompletedMessage DiscriminateCompletedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == Diarization.Name)
                return JsonSerializer.Deserialize<Diarization.Completed>(ref reader, options)!;
            if (subsystem == VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<VoiceprintAggregation.Completed>(ref reader, options)!;
            if (subsystem == Upload.Name)
                return JsonSerializer.Deserialize<Upload.Completed>(ref reader, options)!;
            if (subsystem == TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<TranscriptionTracking.Completed>(ref reader, options)!;
            if (subsystem == TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<TranscriptionTimeLogging.Completed>(ref reader, options)!;
            if (subsystem == TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<TranscriptionCreation.Completed>(ref reader, options)!;
            if (subsystem == MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<MediaFilePackaging.Completed>(ref reader, options)!;
            if (subsystem == CreditReservation.Name)
                return JsonSerializer.Deserialize<CreditReservation.Completed>(ref reader, options)!;
            if (subsystem == MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<MediaFileIndexing.Completed>(ref reader, options)!;
            if (subsystem == MediaIdentification.Name)
                return JsonSerializer.Deserialize<MediaIdentification.Completed>(ref reader, options)!;
            if (subsystem == ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<ProjectStatusMonitor.Completed>(ref reader, options)!;
            if (subsystem == Recognition.Name)
                return JsonSerializer.Deserialize<Recognition.Completed>(ref reader, options)!;
            if (subsystem == SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<SpeakerIdentification.Completed>(ref reader, options)!;
            if (subsystem == Spp.Name)
                return JsonSerializer.Deserialize<Spp.Completed>(ref reader, options)!;
            if (subsystem == TranscodingVideo.Name)
                return JsonSerializer.Deserialize<TranscodingVideo.Completed>(ref reader, options)!;
            if (subsystem == TranscodingAudio.Name)
                return JsonSerializer.Deserialize<TranscodingAudio.Completed>(ref reader, options)!;
            if (subsystem == ChainControl.Name)
                return JsonSerializer.Deserialize<ChainControl.Completed>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static FailedMessage DiscriminateFailedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == Diarization.Name)
                return JsonSerializer.Deserialize<Diarization.Failed>(ref reader, options)!;
            if (subsystem == VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<VoiceprintAggregation.Failed>(ref reader, options)!;
            if (subsystem == Upload.Name)
                return JsonSerializer.Deserialize<Upload.Failed>(ref reader, options)!;
            if (subsystem == TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<TranscriptionTracking.Failed>(ref reader, options)!;
            if (subsystem == TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<TranscriptionTimeLogging.Failed>(ref reader, options)!;
            if (subsystem == TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<TranscriptionCreation.Failed>(ref reader, options)!;
            if (subsystem == MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<MediaFilePackaging.Failed>(ref reader, options)!;
            if (subsystem == CreditReservation.Name)
                return JsonSerializer.Deserialize<CreditReservation.Failed>(ref reader, options)!;
            if (subsystem == MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<MediaFileIndexing.Failed>(ref reader, options)!;
            if (subsystem == MediaIdentification.Name)
                return JsonSerializer.Deserialize<MediaIdentification.Failed>(ref reader, options)!;
            if (subsystem == ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<ProjectStatusMonitor.Failed>(ref reader, options)!;
            if (subsystem == Recognition.Name)
                return JsonSerializer.Deserialize<Recognition.Failed>(ref reader, options)!;
            if (subsystem == SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<SpeakerIdentification.Failed>(ref reader, options)!;
            if (subsystem == Spp.Name)
                return JsonSerializer.Deserialize<Spp.Failed>(ref reader, options)!;
            if (subsystem == TranscodingVideo.Name)
                return JsonSerializer.Deserialize<TranscodingVideo.Failed>(ref reader, options)!;
            if (subsystem == TranscodingAudio.Name)
                return JsonSerializer.Deserialize<TranscodingAudio.Failed>(ref reader, options)!;
            if (subsystem == ChainControl.Name)
                return JsonSerializer.Deserialize<ChainControl.Failed>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static ProgressMessage DiscriminateProgressMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == Diarization.Name)
                return JsonSerializer.Deserialize<Diarization.Progress>(ref reader, options)!;
            if (subsystem == VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<VoiceprintAggregation.Progress>(ref reader, options)!;
            if (subsystem == Upload.Name)
                return JsonSerializer.Deserialize<Upload.Progress>(ref reader, options)!;
            if (subsystem == TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<TranscriptionTracking.Progress>(ref reader, options)!;
            if (subsystem == TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<TranscriptionTimeLogging.Progress>(ref reader, options)!;
            if (subsystem == TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<TranscriptionCreation.Progress>(ref reader, options)!;
            if (subsystem == MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<MediaFilePackaging.Progress>(ref reader, options)!;
            if (subsystem == CreditReservation.Name)
                return JsonSerializer.Deserialize<CreditReservation.Progress>(ref reader, options)!;
            if (subsystem == MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<MediaFileIndexing.Progress>(ref reader, options)!;
            if (subsystem == MediaIdentification.Name)
                return JsonSerializer.Deserialize<MediaIdentification.Progress>(ref reader, options)!;
            if (subsystem == ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<ProjectStatusMonitor.Progress>(ref reader, options)!;
            if (subsystem == Recognition.Name)
                return JsonSerializer.Deserialize<Recognition.Progress>(ref reader, options)!;
            if (subsystem == SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<SpeakerIdentification.Progress>(ref reader, options)!;
            if (subsystem == Spp.Name)
                return JsonSerializer.Deserialize<Spp.Progress>(ref reader, options)!;
            if (subsystem == TranscodingVideo.Name)
                return JsonSerializer.Deserialize<TranscodingVideo.Progress>(ref reader, options)!;
            if (subsystem == TranscodingAudio.Name)
                return JsonSerializer.Deserialize<TranscodingAudio.Progress>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

    }
}
