
namespace KeyboardHookLab.Domain.Entities;

public sealed class KeyboardEventEntry
{
    public DateTimeOffset Timestamp { get; }

    public string EventType { get; }

    public string KeyName { get; }

    public string Source { get; }

    public string DisplayText { get; }

    public KeyboardEventEntry(
        DateTimeOffset timestamp,
        string eventType,
        string keyName,
        string source)
    {
        Timestamp = timestamp;
        EventType = eventType;
        KeyName = keyName;
        Source = source;

        DisplayText =
            $"[{Timestamp:HH:mm:ss.fff}] [{Source}] [{EventType}] {KeyName}";
    }
}
