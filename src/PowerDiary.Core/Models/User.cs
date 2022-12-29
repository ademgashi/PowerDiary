using PowerDiary.Core.Interfaces;
using GuardNet;

namespace PowerDiary.Core.Models
{
    public class User : IEntity<int>
{
        public User(string name)
        {
            Guard.NotNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public string Name { get; set; }
        public ICollection<ChatEvent> SentEvents { get; set; }
        public ICollection<ChatEvent> ReceivedEvents { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int Id { get; set; }
}
}
