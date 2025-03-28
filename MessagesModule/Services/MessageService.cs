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
                var messages = await _messageRepository.FindListByCondition(x => x.Receiver.UserId == id && x.Sender.UserId == sender.UserId 
                || x.ReceiverId == _currentUser.UserId && x.SenderId == id);                                   
                
                return messages;
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
                var receiver = await _userRepository.Get(request.ReceiverId);
   
                if (receiver == null || receiver.CompanyId != _currentUser.CompanyId) 
                    throw new Exception("Receiver does not exist in the company");

                if (_currentUser.UserId == receiver.UserId)
                    throw new Exception("You can not send an automessage");


                var message = new Message()
                {
                    Content = request.Content,
                    SenderId = _currentUser.UserId,
                    ReceiverId = request.ReceiverId,
                    CompanyId = _currentUser.CompanyId,
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