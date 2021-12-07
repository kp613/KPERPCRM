using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Models.AppIdentityModels;
using API.Helpers.Pagination;
using API.Helpers.Params;

namespace API.Repository.IRepository
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);
        Task<bool> SaveAllAsync();
    }
}
