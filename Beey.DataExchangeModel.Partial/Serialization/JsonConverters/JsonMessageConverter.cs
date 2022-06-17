using Beey.DataExchangeModel.Messaging;
using Beey.DataExchangeModel.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Serialization.JsonConverters
{
    public class JsonMessageConverter : JsonConverter<Message>
    {
        #region constructors
        // ensurance that messages are deserialized correctly
        private static readonly ConstructorInfo startedMessageConstructor = typeof(StartedMessage)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(DateTimeOffset), typeof(int), typeof(int?), typeof(IConfiguration) }, null);
        private static readonly ConstructorInfo progressMessageConstructor = typeof(ProgressMessage)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(DateTimeOffset), typeof(int), typeof(int?), typeof(JsonData) }, null);
        private static readonly ConstructorInfo failedMessageConstructor = typeof(FailedMessage)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(DateTimeOffset), typeof(int), typeof(int?), typeof(string) }, null);
        private static readonly ConstructorInfo completedMessageConstructor = typeof(CompletedMessage)
            .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(DateTimeOffset), typeof(int), typeof(int?) }, null);
        #endregion constructors

        #region property names
        private static readonly string idPropertyName = nameof(Message.Id);
        private static readonly string idPropertyNameLower = idPropertyName.ToLowerInvariant();
        private static readonly string typePropertyName = nameof(Message.Type);
        private static readonly string typePropertyNameLower = typePropertyName.ToLowerInvariant();
        private static readonly string subsystemPropertyName = nameof(Message.Subsystem);
        private static readonly string subsystemPropertyNameLower = subsystemPropertyName.ToLowerInvariant();
        private static readonly string sentPropertyName = nameof(Message.Sent);
        private static readonly string sentPropertyNameLower = sentPropertyName.ToLowerInvariant();
        private static readonly string projectIdPropertyName = nameof(Message.ProjectId);
        private static readonly string projectIdPropertyNameLower = projectIdPropertyName.ToLowerInvariant();

        private static readonly string configPropertyName = nameof(StartedMessage.Config);
        private static readonly string configPropertyNameLower = configPropertyName.ToLowerInvariant();
        private static readonly string dataPropertyName = nameof(ProgressMessage.Data);
        private static readonly string dataPropertyNameLower = dataPropertyName.ToLowerInvariant();
        private static readonly string reasonPropertyName = nameof(FailedMessage.Reason);
        private static readonly string reasonPropertyNameLower = reasonPropertyName.ToLowerInvariant();
        #endregion property names

        private static readonly JsonConverter configSerializer
            = new JsonSimpleConverter<IConfiguration>(serialize: SerializeConfiguration);
        private static readonly JsonConverter dataSerializer
            = new JsonSimpleConverter<JsonData>(serialize: SerializeJsonData);

        private JsonMessageConverter() { }
        public static JsonSerializerOptions CreateDefaultOptions()
            => new JsonSerializerOptions().AddConverters(new JsonMessageConverter(), configSerializer, dataSerializer);

        public override Message Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var properties = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader, options);
            if (options.PropertyNameCaseInsensitive)
            {
                properties = properties.ToDictionary(key => key.Key.ToLowerInvariant(), value => value.Value);
            }
            if (!properties.TryGetValue(options.PropertyNameCaseInsensitive ? typePropertyNameLower : typePropertyName, out var typeProp))
            {
                throw new JsonException($"Invalid JSON. Missing message property '{typePropertyName}'.");
            }

            var messageType = typeProp.ValueKind switch
            {
                JsonValueKind.Number => (MessageType)typeProp.GetInt32(),
                JsonValueKind.String => Enum.Parse<MessageType>(typeProp.GetString()),
                _ => throw new JsonException("Invalid message type.")
            };

            try
            {
                return messageType switch
                {
                    MessageType.Started => DeserializeStartedMessage(properties, options),
                    MessageType.Progress => DeserializeProgressMessage(properties, options),
                    MessageType.Failed => DeserializeFailedMessage(properties, options),
                    MessageType.Completed => DeserializeCompletedMessage(properties, options),
                    _ => throw new JsonException($"Invalid message type '{messageType}'.")
                };
            }
            catch (JsonException) { throw; }
            catch (Exception ex)
            {
                throw new JsonException("Error when deserializing message.", ex);
            }
        }

        private static StartedMessage DeserializeStartedMessage(Dictionary<string, JsonElement> props, JsonSerializerOptions options)
        {
            CheckConstructor(startedMessageConstructor);
            var message = DeserializeMessage(props, options);
            var config = DeserializeConfiguration(props[options.PropertyNameCaseInsensitive ? configPropertyNameLower : configPropertyName]);
            return FastActivator<StartedMessage>.CreateInstance(startedMessageConstructor,
                message.SubsystemName, message.Sent, message.Id, message.ProjectId,
                config);
        }
        private static ProgressMessage DeserializeProgressMessage(Dictionary<string, JsonElement> props, JsonSerializerOptions options)
        {
            CheckConstructor(progressMessageConstructor);
            var message = DeserializeMessage(props, options);
            var data = props[options.PropertyNameCaseInsensitive ? dataPropertyNameLower : dataPropertyName];
            return FastActivator<ProgressMessage>.CreateInstance(progressMessageConstructor,
                message.SubsystemName, message.Sent, message.Id, message.ProjectId,
                new JsonData(data.GetRawText()));
        }
        private static FailedMessage DeserializeFailedMessage(Dictionary<string, JsonElement> props, JsonSerializerOptions options)
        {
            CheckConstructor(failedMessageConstructor);
            var message = DeserializeMessage(props, options);
            return FastActivator<FailedMessage>.CreateInstance(failedMessageConstructor,
                message.SubsystemName, message.Sent, message.Id, message.ProjectId,
                props[options.PropertyNameCaseInsensitive ? reasonPropertyNameLower : reasonPropertyName].GetString());
        }
        private static CompletedMessage DeserializeCompletedMessage(Dictionary<string, JsonElement> props, JsonSerializerOptions options)
        {
            CheckConstructor(completedMessageConstructor);
            var message = DeserializeMessage(props, options);
            return FastActivator<CompletedMessage>.CreateInstance(completedMessageConstructor,
                message.SubsystemName, message.Sent, message.Id, message.ProjectId);
        }

        private static (string SubsystemName, DateTimeOffset Sent, int Id, int? ProjectId) DeserializeMessage(Dictionary<string, JsonElement> props, JsonSerializerOptions options)
        {
            int id = props[options.PropertyNameCaseInsensitive ? idPropertyNameLower : idPropertyName].GetInt32();
            DateTimeOffset sent = props[options.PropertyNameCaseInsensitive ? sentPropertyNameLower : sentPropertyName].GetDateTimeOffset();
            string subsystemName = props[options.PropertyNameCaseInsensitive ? subsystemPropertyNameLower : subsystemPropertyName].GetString();
            int? projectId = null;
            if (props.TryGetValue(options.PropertyNameCaseInsensitive ? projectIdPropertyNameLower : projectIdPropertyName, out var projectIdProp))
            {
                if (projectIdProp.ValueKind == JsonValueKind.Number && projectIdProp.TryGetInt32(out var tmp))
                {
                    projectId = tmp;
                }
                else if (projectIdProp.ValueKind != JsonValueKind.Null)
                {
                    throw new JsonException($"Error when parsing '{projectIdPropertyName}'. Expected number instead of '{projectIdProp.ValueKind}'.");
                }
            }
            return (subsystemName, sent, id, projectId);
        }
        private static IConfiguration DeserializeConfiguration(JsonElement json)
        {
            var inMemoryCollection = new Dictionary<string, string>();
            var stack = new Stack<(string Path, JsonElement Value)>();
            foreach (var prop in json.EnumerateObject())
            {
                stack.Push((prop.Name.ToLower(), prop.Value));
            }
            while (stack.Any())
            {
                var current = stack.Pop();
                if (current.Value.ValueKind == JsonValueKind.Array)
                {
                    int index = 0;
                    foreach (var elem in current.Value.EnumerateArray())
                    {
                        stack.Push(($"{current.Path}:{index}", elem));
                        index++;
                    }
                }
                else if (current.Value.ValueKind == JsonValueKind.Object)
                {
                    foreach (var prop in current.Value.EnumerateObject())
                    {
                        stack.Push(($"{current.Path}:{prop.Name}", prop.Value));
                    }
                }
                else
                {
                    inMemoryCollection.Add(current.Path, current.Value.ToString());
                }
            }
            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemoryCollection)
                .Build();
        }
        private static void CheckConstructor(ConstructorInfo messageConstructor)
        {
            if (messageConstructor == null)
                throw new InvalidProgramException("Missing message constructor.");
        }

        public override void Write(Utf8JsonWriter writer, Message value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }

        private static void SerializeConfiguration(Utf8JsonWriter writer, IConfiguration configuration, JsonSerializerOptions options)
        {
            var dictionary = new Dictionary<string, object>();
            var props = configuration.GetChildren();
            foreach (var prop in props)
            {
                (string key, object obj) = ConvertConfigurationSection(prop);
                dictionary.Add(key, obj);
            }

            JsonSerializer.Serialize(writer, dictionary, options);
        }
        private static (string Key, object Value) ConvertConfigurationSection(IConfigurationSection section)
        {
            string key = section.Key;
            var children = section.GetChildren();
            if (!children.Any())
            {
                return (key, section.Value);
            }
            else if (int.TryParse(children.First().Key, out _))
            {
                var result = new List<object>();
                foreach (var child in children)
                {
                    (_, var childValue) = ConvertConfigurationSection(child);
                    result.Add(childValue);
                }
                return (key, result);
            }
            else
            {
                var result = new Dictionary<string, object>();
                foreach (var child in children)
                {
                    (var childKey, var childValue) = ConvertConfigurationSection(child);
                    result.Add(childKey, childValue);
                }
                return (key, result);
            }
        }
        private static void SerializeJsonData(Utf8JsonWriter writer, JsonData jsonData, JsonSerializerOptions options)
        {
            // TODO System.Text.Json does not support writing raw string, so we need to re-parse it
            JsonSerializer.Serialize(writer, JsonDocument.Parse(jsonData.Raw).RootElement, options);
        }
    }
}
