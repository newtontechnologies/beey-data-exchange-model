﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Common.Transcriptions;

public abstract class NgItem
{
    private const string Prop_Type = "t";
    private const string Prop_Tags = "tags";
    private const string Prop_Timestamp = "ms";
    private const string Prop_Text = "txt";
    private const string Prop_Voiceprint = "vp";
    private const string Prop_Confidence = "c";

    private const string Type_Timestamp = "ms";
    private const string Type_Text = "txt";
    private const string Type_Voiceprint = "vp";
    private const string Type_Confidence = "c";

    public IEnumerable<string> Tags { get; }
    public NgItem(IEnumerable<string> tags)
    {
        Tags = tags;
    }

    public abstract T Match<T>(Func<Timestamp, T> ts, Func<Text, T> txt, Func<Voiceprint, T> vp, Func<Confidence, T> c);
    public abstract void Switch(Action<Timestamp> ts, Action<Text> txt, Action<Voiceprint> vp, Action<Confidence> c);

    public JsonObject Serialize()
    {
        var result = new JsonObject();
        this.Switch(
            ts => (result[Prop_Type], result[Prop_Timestamp]) = (Type_Timestamp, ts.Milliseconds),
            txt => (result[Prop_Type], result[Prop_Text]) = (Type_Text, txt.Value),
            vp => (result[Prop_Type], result[Prop_Voiceprint]) = (Type_Voiceprint, vp.Value),
            c => (result[Prop_Type], result[Prop_Confidence]) = (Type_Confidence, c.Value));

        result[Prop_Tags] = JsonSerializer.SerializeToNode(Tags);

        return result;
    }

    public static NgItem? Deserialize(JsonObject? jsonObject)
    {
        if (jsonObject == null)
            return null;

        var tags = jsonObject[Prop_Tags]?.Deserialize<string[]>()
            ?? Array.Empty<string>();

        return jsonObject[Prop_Type]?.GetValue<string>() switch
        {
            Type_Timestamp => new Timestamp(
                jsonObject.TryGetPropertyValue(Prop_Timestamp, out var v)
                    ? v?.GetValue<double>() ?? throw new JsonException("Timestamp value cannot be null.")
                    : throw new JsonException("Missing timestamp property."), tags),
            Type_Text => new Text(
                jsonObject.TryGetPropertyValue(Prop_Text, out var v)
                    ? v?.GetValue<string>() ?? ""
                    : throw new JsonException("Missing text property."), tags),
            Type_Voiceprint => new Voiceprint(
                jsonObject.TryGetPropertyValue(Prop_Voiceprint, out var v)
                    ? v?.GetValue<string>() ?? throw new JsonException("Missing voiceprint value.")
                    : throw new JsonException("Missing voiceprint property."), tags),
            Type_Confidence => new Confidence(
                jsonObject.TryGetPropertyValue(Prop_Confidence, out var c)
                    ? c?.GetValue<double>() ?? throw new JsonException("Missing confidence value.")
                    : throw new JsonException("Missing confidence property."), tags),
            _ => throw new JsonException($"Unknown {nameof(NgItem)} type.")
        };
    }

    public sealed class Timestamp : NgItem
    {
        public Timestamp(TimeSpan timeSpan, IEnumerable<string> tags)
            : this(timeSpan.TotalMilliseconds, tags) { }
        public Timestamp(double ms, IEnumerable<string> tags) : base(tags)
        {
            Milliseconds = ms;
        }

        public double Milliseconds { get; }

        public override T Match<T>(Func<Timestamp, T> ts, Func<Text, T> txt, Func<Voiceprint, T> vp, Func<Confidence, T> c)
            => ts(this);
        public override void Switch(Action<Timestamp> ts, Action<Text> txt, Action<Voiceprint> vp, Action<Confidence> c)
            => ts(this);
    }

    public sealed class Text : NgItem
    {
        public Text(string value, IEnumerable<string> tags) : base(tags)
        {
            Value = value;
        }

        public string Value { get; }

        public override T Match<T>(Func<Timestamp, T> ts, Func<Text, T> txt, Func<Voiceprint, T> vp, Func<Confidence, T> c)
            => txt(this);
        public override void Switch(Action<Timestamp> ts, Action<Text> txt, Action<Voiceprint> vp, Action<Confidence> c)
            => txt(this);
    }

    public sealed class Voiceprint : NgItem
    {
        public Voiceprint(string value, IEnumerable<string> tags) : base(tags)
        {
            Value = value;
        }

        public string Value { get; }

        public override T Match<T>(Func<Timestamp, T> ts, Func<Text, T> txt, Func<Voiceprint, T> vp, Func<Confidence, T> c)
            => vp(this);
        public override void Switch(Action<Timestamp> ts, Action<Text> txt, Action<Voiceprint> vp, Action<Confidence> c)
            => vp(this);
    }

    public sealed class Confidence : NgItem
    {
        public Confidence(double value, IEnumerable<string> tags) : base(tags)
        {
            Value = value;
        }

        public double Value { get; }

        public override T Match<T>(Func<Timestamp, T> ts, Func<Text, T> txt, Func<Voiceprint, T> vp, Func<Confidence, T> c)
            => c(this);
        public override void Switch(Action<Timestamp> ts, Action<Text> txt, Action<Voiceprint> vp, Action<Confidence> c)
            => c(this);
    }
}
