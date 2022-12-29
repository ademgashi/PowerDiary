using PowerDiary.Core.Models;

namespace PowerDiary.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(ChatDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User("Bob"),
                    new User("Kate")

                );
                context.SaveChanges();
            }

            if (!context.ChatEvents.Any())
            {
                context.ChatEvents.AddRange(
                    new ChatEvent(context.Users.First(x => x.Name == "Bob"), EventType.EnterRoom, new DateTime
                        (2022, 1, 1, 17, 0, 0), null, null),
                    new
                        ChatEvent(context.Users.First(x => x.Name == "Kate"), EventType.EnterRoom, new DateTime
                            (2022, 1, 1, 17, 5, 0), null, null),
                    new
                        ChatEvent(context.Users.First(x => x.Name == "Bob"), EventType.Comment, new DateTime
                                (2022, 1, 1, 17, 15, 0), context.Users.First(x => x.Name == "Kate"),
                            "Hey, Kate - high five?"),
                    new
                        ChatEvent(context.Users.First(x => x.Name == "Kate"), EventType.HighFive, new DateTime
                                (2022, 1, 1, 17, 17, 0), context.Users.First(x => x.Name == "Bob"),
                            ""),

                    new
                        ChatEvent(context.Users.First(x => x.Name == "Bob"), EventType.LeaveRoom, new DateTime
                            (2022, 1, 1, 17, 18, 0), null, ""),

                    new
                        ChatEvent(context.Users.First(x => x.Name == "Kate"), EventType.Comment, new DateTime
                                (2022, 1, 1, 17, 20, 0), context.Users.First(x => x.Name == "Kate"),
                            "Oh, typical")



                    );
                context.SaveChanges();


            }

            //var users = new List<User>
            //{
            //    new User { Id = 1, Name = "Bob" },
            //    new User { Id = 2, Name = "Kate" },
            //    new User { Id = 3, Name = "Alice" },
            //    new User { Id = 4, Name = "John" }
            //};

            //context.Users.AddRange(users);
            //context.SaveChanges();

          

            //var chatEvents = new List<ChatEvent>
            //{
            //    new ChatEvent { Id = 1, SenderId = 1, ReceiverId = 2, Type = EventType.EnterRoom, Timestamp = new DateTime(2022, 1, 1, 17, 0, 0) },
            //    new ChatEvent { Id = 2, SenderId = 2, ReceiverId = 1, Type = EventType.EnterRoom, Timestamp = new DateTime(2022, 1, 1, 17, 5, 0) },
            //    new ChatEvent { Id = 3, SenderId = 1, ReceiverId = 2, Type = EventType.Comment, Timestamp = new DateTime(2022, 1, 1, 17, 15, 0), Message = "Hey, Kate - high five?"},
            //    new ChatEvent { Id = 4, SenderId = 2, ReceiverId = 1, Type = EventType.HighFive, Timestamp = new DateTime(2022, 1, 1, 17, 17, 0) },
            //    new ChatEvent { Id = 5, SenderId = 1, ReceiverId = null, Type = EventType.LeaveRoom, Timestamp = new DateTime(2022, 1, 1, 17, 18, 0) },
            //    new ChatEvent { Id = 6, SenderId = 2, ReceiverId = null, Type = EventType.Comment, Timestamp = new DateTime(2022, 1, 1, 17, 20, 0), Message = "Oh, typical"},
            //    new ChatEvent { Id = 7, SenderId = 2, ReceiverId = null, Type = EventType.LeaveRoom, Timestamp = new DateTime(2022, 1, 1, 17, 21, 0) }
            //};

            //context.ChatEvents.AddRange(chatEvents);
            //context.SaveChanges();
            
        }
    }
}
