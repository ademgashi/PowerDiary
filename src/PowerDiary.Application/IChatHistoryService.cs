using PowerDiary.Core.Models;

namespace PowerDiary.Application;


public enum Granularity
{
    MinuteByMinute,
    Hourly
}

public interface IChatHistoryService
{
    IEnumerable<ChatEvent> GetChatHistory(Granularity granularity);
}