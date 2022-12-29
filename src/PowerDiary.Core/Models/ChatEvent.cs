using GuardNet;
using PowerDiary.Core.Interfaces;
namespace PowerDiary.Core.Models;


public class ChatEvent : IEntity<int>
{
    public ChatEvent(User sender, EventType type, DateTime timestamp, User receiver, string? message = "")
    {
        Guard.NotNull(sender, nameof(sender));
        Sender = sender;
        Type = type;
        Timestamp = timestamp;
        Receiver = receiver;
        Message = message;
    }

    public ChatEvent(User sender, User receiver, EventType type, DateTime timestamp)
    {
        Guard.NotNull(sender, nameof(sender));
        Guard.NotNull(receiver, nameof(receiver));
        Sender = sender;
        Receiver = receiver;
        Type = type;
        Timestamp = timestamp;
    }

    public ChatEvent()
    {

    }



    public int SenderId { get; set; }
    public User Sender { get; set; }
    public int? ReceiverId { get; set; }
    public User? Receiver { get; set; }
    
    public EventType Type { get; init; }
    public DateTime Timestamp { get; init; }
    public string? Message { get; init; }

    public int Id { get; set; }

    public override string ToString()


    {
        switch (Type)
        {
            case EventType.EnterRoom:
                return "enters the room";
            case EventType.LeaveRoom:
                return "leaves the room";
            case EventType.Comment:
                return $"comments: \"{Message}\"";
            case EventType.HighFive:
                return $"high-fives {Receiver?.Name}";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }



}
