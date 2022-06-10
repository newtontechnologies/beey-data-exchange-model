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
            if (propertyName != "Type")
                throw new JsonException();

            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();


            if (!Enum.TryParse<MessageType>(reader.GetString(), out var messageType))
                throw new JsonException();

            return messageType switch
            {
                MessageType.Started => JsonSerializer.Deserialize<StartedMessage>(ref reader, options)!,
                MessageType.Progress => JsonSerializer.Deserialize<ProgressMessage>(ref reader, options)!,
                MessageType.Failed => JsonSerializer.Deserialize<FailedMessage>(ref reader, options)!,
                MessageType.Completed => JsonSerializer.Deserialize<CompletedMessage>(ref reader, options)!,
                MessageType.ChainStatus => JsonSerializer.Deserialize<ChainStatusMessage>(ref reader, options)!,
                MessageType.ChainCommand => JsonSerializer.Deserialize<ChainCommandMessage>(ref reader, options)!,
                _ => throw new JsonException($"Unknown messageType: {messageType}"),
            };
        }

        public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(value, options);
    }
}
