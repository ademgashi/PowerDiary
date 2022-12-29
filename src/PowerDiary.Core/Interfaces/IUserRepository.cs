using PowerDiary.Core.Models;


namespace PowerDiary.Core.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        void Update(User user);
        void Remove(User user);
    }
}
