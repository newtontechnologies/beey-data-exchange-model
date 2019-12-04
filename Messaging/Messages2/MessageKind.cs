using System;
using System.Reflection;

namespace Beey.DataExchangeModel.Messaging.Messages2
{
    public abstract class MessageKind<TKind, TMessage> : IEquatable<MessageKind<TKind, TMessage>>
        where TKind : MessageKind<TKind, Message<TKind>>
        where TMessage : Message<TKind>
    {
        public static readonly TKind Started = (TKind)Activator.CreateInstance(typeof(TKind), nameof(Started), 1);
        public static readonly TKind Completed = (TKind)Activator.CreateInstance(typeof(TKind), nameof(Completed), 2);
        public string Name { get; set; }
        public int Value { get; set; }
        public MessageKind(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public static TKind Parse(string name)
        {
            FieldInfo[] allValues = typeof(TKind).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var val in allValues)
            {
                var t = (TKind)val.GetValue(null);
                if (t.Name.ToLowerInvariant() == name.ToLowerInvariant())
                {
                    return t;
                }
            }
            throw new ArgumentException("Invalid name.");
        }
        public static TKind Parse(int value)
        {
            FieldInfo[] allValues = typeof(TKind).GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (var val in allValues)
            {
                var t = (TKind)val.GetValue(null);
                if (t.Value == value)
                {
                    return t;
                }
            }
            throw new ArgumentException("Invalid name.");
        }
        public override string ToString() => Name;
        public override bool Equals(object obj) => Equals(obj as MessageKind<TKind, TMessage>);
        public bool Equals(MessageKind<TKind, TMessage> other) => ReferenceEquals(this, other);
        public override int GetHashCode() => base.GetHashCode();
        public static bool operator ==(MessageKind<TKind, TMessage> first, MessageKind<TKind, TMessage> second) => ReferenceEquals(first, second);
        public static bool operator !=(MessageKind<TKind, TMessage> first, MessageKind<TKind, TMessage> second) => !(first == second);
        public static bool operator ==(MessageKind<TKind, TMessage> kind, int value) => kind != null ? kind.Value == value : false;
        public static bool operator !=(MessageKind<TKind, TMessage> kind, int value) => !(kind == value);
        public static bool operator ==(int value, MessageKind<TKind, TMessage> kind) => kind == value;
        public static bool operator !=(int value, MessageKind<TKind, TMessage> kind) => kind != value;

        public static implicit operator MessageKind<TKind, TMessage>(int value) => Parse(value);
        public static implicit operator MessageKind<TKind, TMessage>(string name) => Parse(name);

        public static implicit operator TKind(MessageKind<TKind, TMessage> messageKind) => messageKind.Self;
        public static implicit operator MessageKind<TKind, TMessage>(TKind messageKind) => messageKind;
        protected TKind Self { get => this; }
    }

    public sealed class ASRMsgKind : MessageKind<ASRMsgKind, Message<ASRMsgKind>>
    {
        public static readonly ASRMsgKind Phrase = new ASRMsgKind(nameof(Phrase), 3);
        public static readonly ASRMsgKind Speaker = new ASRMsgKind(nameof(Speaker), 4);
        public static readonly ASRMsgKind SpeakerRecovery = new ASRMsgKind(nameof(SpeakerRecovery), 5);
        public ASRMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator ASRMsgKind(int value) => Parse(value);
        public static implicit operator ASRMsgKind(string name) => Parse(name);
    }
    public sealed class AudioExtractionMsgKind : MessageKind<AudioExtractionMsgKind, Message<AudioExtractionMsgKind>>
    {
        public static readonly AudioExtractionMsgKind Failed = new AudioExtractionMsgKind(nameof(Failed), 3);
        public AudioExtractionMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator AudioExtractionMsgKind(int value) => Parse(value);
        public static implicit operator AudioExtractionMsgKind(string name) => Parse(name);
    }
    public sealed class DiarizationMsgKind : MessageKind<DiarizationMsgKind, Message<DiarizationMsgKind>>
    {
        public static readonly DiarizationMsgKind Failed = new DiarizationMsgKind(nameof(Failed), 3);
        public static readonly DiarizationMsgKind Interrupted = new DiarizationMsgKind(nameof(Interrupted), 4);
        public DiarizationMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator DiarizationMsgKind(int value) => Parse(value);
        public static implicit operator DiarizationMsgKind(string name) => Parse(name);
    }
    public sealed class FileUploadMsgKind : MessageKind<FileUploadMsgKind, Message<FileUploadMsgKind>>
    {
        public static readonly FileUploadMsgKind Failed = new FileUploadMsgKind(nameof(Failed), 3);
        public static readonly FileUploadMsgKind UploadedBytes = new FileUploadMsgKind(nameof(UploadedBytes), 4);

        public FileUploadMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator FileUploadMsgKind(int value) => Parse(value);
        public static implicit operator FileUploadMsgKind(string name) => Parse(name);
    }
    public sealed class RecognitionMsgKind : MessageKind<RecognitionMsgKind, Message<RecognitionMsgKind>>
    {
        public static readonly RecognitionMsgKind Cancelled = new RecognitionMsgKind(nameof(Cancelled), 3);
        public RecognitionMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator RecognitionMsgKind(int value) => Parse(value);
        public static implicit operator RecognitionMsgKind(string name) => Parse(name);
    }
    public sealed class RecordingConversionMsgKind : MessageKind<RecordingConversionMsgKind, Message<RecordingConversionMsgKind>>
    {
        public static readonly RecordingConversionMsgKind Failed = new RecordingConversionMsgKind(nameof(Failed), 3);
        public static readonly RecordingConversionMsgKind Progress = new RecordingConversionMsgKind(nameof(Progress), 4);
        public RecordingConversionMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator RecordingConversionMsgKind(int value) => Parse(value);
        public static implicit operator RecordingConversionMsgKind(string name) => Parse(name);
    }
    public sealed class RecordingInfoMsgKind : MessageKind<RecordingInfoMsgKind, Message<RecordingInfoMsgKind>>
    {
        public static readonly RecordingInfoMsgKind Failed = new RecordingInfoMsgKind(nameof(Failed), 3);
        public static readonly RecordingInfoMsgKind RawFileInfo = new RecordingInfoMsgKind(nameof(RawFileInfo), 4);
        public static readonly RecordingInfoMsgKind ApproximateDuration = new RecordingInfoMsgKind(nameof(ApproximateDuration), 5);
        public static readonly RecordingInfoMsgKind Duration = new RecordingInfoMsgKind(nameof(Duration), 6);
        public RecordingInfoMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator RecordingInfoMsgKind(int value) => Parse(value);
        public static implicit operator RecordingInfoMsgKind(string name) => Parse(name);
    }
    public sealed class SpeakerIdentificationMsgKind : MessageKind<SpeakerIdentificationMsgKind, Message<SpeakerIdentificationMsgKind>>
    {
        public static readonly SpeakerIdentificationMsgKind Failed = new SpeakerIdentificationMsgKind(nameof(Failed), 3);
        public static readonly SpeakerIdentificationMsgKind Speaker = new SpeakerIdentificationMsgKind(nameof(Speaker), 4);
        public static readonly SpeakerIdentificationMsgKind Unidentified = new SpeakerIdentificationMsgKind(nameof(Speaker), 5);
        public SpeakerIdentificationMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator SpeakerIdentificationMsgKind(int value) => Parse(value);
        public static implicit operator SpeakerIdentificationMsgKind(string name) => Parse(name);
    }
    public sealed class TagChangeMsgKind : MessageKind<TagChangeMsgKind, Message<TagChangeMsgKind>>
    {
        public static readonly TagChangeMsgKind Added = new TagChangeMsgKind(nameof(Added), 3);
        public static readonly TagChangeMsgKind Removed = new TagChangeMsgKind(nameof(Removed), 4);
        public TagChangeMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator TagChangeMsgKind(int value) => Parse(value);
        public static implicit operator TagChangeMsgKind(string name) => Parse(name);
    }
    public sealed class TranscriptionMsgKind : MessageKind<TranscriptionMsgKind, Message<TranscriptionMsgKind>>
    {
        public static readonly TranscriptionMsgKind Failed = new TranscriptionMsgKind(nameof(Failed), 3);
        public static readonly TranscriptionMsgKind Interrupted = new TranscriptionMsgKind(nameof(Interrupted), 4);
        public TranscriptionMsgKind(string name, int value) : base(name, value) { }
        public static implicit operator TranscriptionMsgKind(int value) => Parse(value);
        public static implicit operator TranscriptionMsgKind(string name) => Parse(name);
    }
}
