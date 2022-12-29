using PowerDiary.Core.Models;

namespace PowerDiary.Core.Interfaces;
public interface IChatEventRepository
{
    Task<ChatEvent> GetByIdAsync(int id);
    Task<IEnumerable<ChatEvent>> GetAllAsync();
    Task AddAsync(ChatEvent chatEvent);
    Task UpdateAsync(ChatEvent chatEvent);
    Task DeleteAsync(ChatEvent chatEvent);
}