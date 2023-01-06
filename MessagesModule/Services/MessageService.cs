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
                var sender = await _userRepository.Get(request.SenderId);
                var receiver = await _userRepository.Get(request.ReceiverId);
                var message = new Message()
                {
                    Content = request.Content,
                    Sender = sender,
                    Receiver = receiver,
                    CompanyId = sender.CompanyId,
                    Time = DateTime.Now,
                };

                if (sender != null && receiver != null && sender.Company.Equals(receiver.Company))
                {
                    await _messageRepository.Insert(message);                    
                }
                return message.MessageId;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}