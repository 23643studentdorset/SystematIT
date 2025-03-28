using DataModel;
using MessagesModule.DTOs;

namespace MessagesModule.Interfaces
{
    public interface IMessageService
    {
        Task<int> SendMessage(SendMessageRequest request);

        //Task<IEnumerable<Message>> GetBySenderId(int id);

        Task<IEnumerable<Message>> GetByReceiverId(int id);
    }
}