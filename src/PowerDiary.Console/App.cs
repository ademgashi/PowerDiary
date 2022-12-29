using PowerDiary.Application;
using PowerDiary.Core.Models;

namespace PowerDiary.Console;

public class App
{
    private readonly IChatHistoryService _chatHistoryService;
    public App(IChatHistoryService chatHistoryService)
    {
        _chatHistoryService = chatHistoryService;

    }

    public async Task Run(string[] args)
    {


        // Display chat events in "minute by minute" granularity
        System.Console.WriteLine("Granularity: Minute by minute\n");

        var events = _chatHistoryService.GetChatHistory(Granularity.MinuteByMinute);

        foreach (var chatEvent in events)
        {
            System.Console.WriteLine($"{chatEvent.Timestamp.ToString("t")}: {chatEvent.Sender?.Name} {chatEvent.ToString()}");
        }

        System.Console.WriteLine();

        //// Display chat events in "hourly" granularity
        //System.Console.WriteLine("\nGranularity: Hourly\n");
        ////foreach (var chatEvent in _chatHistoryService.GetChatHistory(Granularity.Hourly))
        ////{
        ////System.Console.WriteLine($"{chatEvent.Timestamp.ToString("t")}: {chatEvent.ToString()}");

        var hourlyAggregates = events
            .GroupBy(ce => ce.Timestamp.Hour)
            .Select(g => new
            {
                Hour = g.Key,
                EnterTheRoomCount = g.Count(ce => ce.Type == EventType.EnterRoom),
                LeaveTheRoomCount = g.Count(ce => ce.Type == EventType.LeaveRoom),
                CommentCount = g.Count(ce => ce.Type == EventType.Comment),
                HighFiveCount = g.Count(ce => ce.Type == EventType.HighFive)
            })
            .OrderByDescending(a => a.Hour)
            .ToList();

        System.Console.WriteLine("Granularity: Hourly\n");

        foreach (var aggregate in hourlyAggregates)
        {
            System.Console.WriteLine($"{aggregate.Hour}pm:");
            System.Console.WriteLine($"\t{aggregate.EnterTheRoomCount} people entered");
            System.Console.WriteLine($"\t{aggregate.LeaveTheRoomCount} people left");
            System.Console.WriteLine($"\t{aggregate.HighFiveCount} people high-fived {aggregate.HighFiveCount / 2} other people");
            System.Console.WriteLine($"\t{aggregate.CommentCount} comments");
        }

        System.Console.ReadLine();

    }
}
