using Microsoft.EntityFrameworkCore;
using PowerDiary.Persistence;

namespace PowerDiary.Core.Tests;

public static class ContextMock
{
    public static ChatDbContext GetMockDBContext(string dbName)
    {

        var options = new DbContextOptionsBuilder<ChatDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        var context = new ChatDbContext(options);

        if (context.ChatEvents.Any()) return context;

        DbInitializer.Initialize(context);

        context.SaveChanges();

        return context;
    }
}