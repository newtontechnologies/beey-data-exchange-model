using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Messaging.Chain;
using Beey.DataExchangeModel.Messaging;

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

                MessageType.ChainStatus => JsonSerializer.Deserialize<KnownSubsystems.Chain.Status>(ref reader, options)!,
                MessageType.ChainCommand => JsonSerializer.Deserialize<KnownSubsystems.Chain.Command>(ref reader, options)!,
                _ => throw new JsonException($"Unknown messageType: {messageType}"),
            };
        }

        public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
        {
            var o2 = new JsonSerializerOptions(options);
            var disc = o2.Converters.First(c=>c is MessageJsonConverterWithTypeDiscriminator);
            o2.Converters.Remove(disc);
            JsonSerializer.Serialize(writer, value, value.GetType(), o2);
        }

        static StartedMessage DiscriminateStartedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == KnownSubsystems.Diarization.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Diarization.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.VoiceprintAggregation.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Upload.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Upload.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTracking.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTimeLogging.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionCreation.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFilePackaging.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.CreditReservation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.CreditReservation.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFileIndexing.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaIdentification.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.ProjectStatusMonitor.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Recognition.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Recognition.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.SpeakerIdentification.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Spp.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Spp.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingVideo.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingVideo.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingAudio.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingAudio.Started>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Chain.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Chain.Started>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static CompletedMessage DiscriminateCompletedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == KnownSubsystems.Diarization.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Diarization.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.VoiceprintAggregation.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Upload.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Upload.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTracking.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTimeLogging.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionCreation.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFilePackaging.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.CreditReservation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.CreditReservation.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFileIndexing.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaIdentification.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.ProjectStatusMonitor.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Recognition.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Recognition.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.SpeakerIdentification.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Spp.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Spp.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingVideo.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingVideo.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingAudio.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingAudio.Completed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Chain.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Chain.Completed>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static FailedMessage DiscriminateFailedMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == KnownSubsystems.Diarization.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Diarization.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.VoiceprintAggregation.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Upload.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Upload.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTracking.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTimeLogging.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionCreation.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFilePackaging.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.CreditReservation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.CreditReservation.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFileIndexing.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaIdentification.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.ProjectStatusMonitor.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Recognition.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Recognition.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.SpeakerIdentification.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Spp.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Spp.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingVideo.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingVideo.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingAudio.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingAudio.Failed>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Chain.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Chain.Failed>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

        static ProgressMessage DiscriminateProgressMessage(ref Utf8JsonReader reader, JsonSerializerOptions? options, string subsystem)
        {
            if (subsystem == KnownSubsystems.Diarization.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Diarization.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.VoiceprintAggregation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.VoiceprintAggregation.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Upload.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Upload.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTracking.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTracking.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionTimeLogging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionTimeLogging.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscriptionCreation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscriptionCreation.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFilePackaging.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFilePackaging.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.CreditReservation.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.CreditReservation.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaFileIndexing.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaFileIndexing.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.MediaIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.MediaIdentification.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.ProjectStatusMonitor.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.ProjectStatusMonitor.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Recognition.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Recognition.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.SpeakerIdentification.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.SpeakerIdentification.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Spp.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Spp.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingVideo.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingVideo.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.TranscodingAudio.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.TranscodingAudio.Progress>(ref reader, options)!;
            if (subsystem == KnownSubsystems.Chain.Name)
                return JsonSerializer.Deserialize<KnownSubsystems.Chain.Progress>(ref reader, options)!;

            throw new NotImplementedException($"Unknown subsystem {subsystem}");
        }

    }
}
