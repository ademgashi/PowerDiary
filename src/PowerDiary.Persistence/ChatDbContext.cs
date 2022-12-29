using Microsoft.EntityFrameworkCore;
using PowerDiary.Core.Models;

namespace PowerDiary.Persistence
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ChatEvent> ChatEvents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatEvent>()
                .HasOne(ce => ce.Sender)
                .WithMany(u => u.SentEvents)
                .HasForeignKey(ce => ce.SenderId);


            modelBuilder.Entity<ChatEvent>()
                .HasOne(ce => ce.Receiver)
                .WithMany(u => u.ReceivedEvents)
                .HasForeignKey(ce => ce.ReceiverId);



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=ChatHistory.db");

            optionsBuilder.UseInMemoryDatabase("ChatHistory");
        }
        
    }
}
