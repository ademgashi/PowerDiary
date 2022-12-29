using PowerDiary.Core.Models;
using Microsoft.EntityFrameworkCore;
using PowerDiary.Persistence;

namespace PowerDiary.Application
{
    public class ChatHistoryService : IChatHistoryService
    {
        private readonly ChatDbContext _context;

        public ChatHistoryService(ChatDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ChatEvent> GetChatHistory(Granularity granularity)
        {
            switch (granularity)
            {
                case Granularity.MinuteByMinute:
                    return _context.ChatEvents.Include(entry => entry.Sender).Include(entry=>entry.Receiver)
                        .OrderBy(x => x.Timestamp);
                case Granularity.Hourly:
                    return _context.ChatEvents
                        .GroupBy(x => new
                        {
                            x.Timestamp.Year,
                            x.Timestamp.Month,
                            x.Timestamp.Day,
                            x.Timestamp.Hour
                        })
                        .Select(g => new ChatEvent
                        {
                            Timestamp = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day, g.Key.Hour, 0, 0),
                            Sender = null,
                            Receiver = null,
                            Type = EventType.Comment,
                            Message = $"{g.Count()} chat events"
                        })
                        .OrderByDescending(x => x.Timestamp);
                default:
                    throw new ArgumentOutOfRangeException(nameof(granularity), granularity, null);
            }
        }
    }
}
