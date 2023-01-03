using DataModel;
using Infrastucture.DataAccess.Interfaces;
using MessagesModule.DTOs;
using MessagesModule.Interfaces;

namespace MessagesModule.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMessageRepository _messageRepository;

        public MessageService(IUserRepository userRepository, ICompanyRepository companyRepository, IMessageRepository messageRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _messageRepository = messageRepository; 
        }

        public async Task<IEnumerable<Message>> GetByReceiverId(int id)
        {
            try
            {
                var result = await _messageRepository.FindListByCondition(x => x.Receiver.UserId == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Message>> GetBySenderId(int id)
        {
            try
            {
                var result = await _messageRepository.FindListByCondition(x => x.Sender.UserId == id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SendMessage(SendMessageRequest request)
        {
            try
            {
                var message = new Message()
                {
                    Content = request.Content,
                    Company = await _companyRepository.Get(2),
                    Sender = await _userRepository.Get(request.SenderId),
                    Receiver = await _userRepository.Get(request.ReceiverId),
                    Time = DateTime.Now,
                };
                 await _messageRepository.Insert(message);
                return message.MessageId;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}