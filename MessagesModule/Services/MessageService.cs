using DataModel;
using Infrastucture.DataAccess.Interfaces;
using Infrastucture.Identity.Interfaces;
using MessagesModule.DTOs;
using MessagesModule.Interfaces;


namespace MessagesModule.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ICurrentUser _currentUser;

        public MessageService(IUserRepository userRepository, ICompanyRepository companyRepository, IMessageRepository messageRepository, ICurrentUser currentUser)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _messageRepository = messageRepository;
            _currentUser = currentUser; 
        }

        public async Task<IEnumerable<Message>> GetByReceiverId(int id)
        {
            try
            {
                var sender = await _userRepository.Get(_currentUser.UserId);
                var messages = await _messageRepository.FindListByCondition(x => x.Receiver.UserId == id && x.Sender.UserId == sender.UserId);                                   
                
                return messages;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
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
        */
        public async Task<int> SendMessage(SendMessageRequest request)
        {
            try
            {
                var receiver = await _userRepository.Get(request.ReceiverId);
                var sender = await _userRepository.Get(_currentUser.UserId);
                var company = await _companyRepository.Get(_currentUser.CompanyId);

                if (receiver == null || receiver.CompanyId != _currentUser.CompanyId) 
                    throw new Exception("Receiver does not exist in the company");
                if (sender == null) 
                    throw new Exception("sender not found");
                if (company == null) 
                    throw new Exception("company not found");

                var message = new Message()
                {
                    Content = request.Content,
                    Sender = sender,
                    Receiver = receiver,
                    Company = company,
                    Time = DateTime.UtcNow,
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