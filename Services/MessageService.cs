using MongoDB.Driver;
using PPChat.Models;
using PPChat.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Services
{
    public class MessageService
    {
        private IMongoCollection<Message> _messages;

        public MessageService(IPPChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Message>(settings.MessagesCollectionName);
        }

        public List<Message> Get() => _messages.Find(m => true).ToList();

        public Message Create(Message m)
        {
            _messages.InsertOne(m);
            return _messages.Find<Message>(msg => msg.Author == m.Author && msg.CreationTime == m.CreationTime).FirstOrDefault();
        }
    }
}
