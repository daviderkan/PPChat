using MongoDB.Driver;
using PPChat.Models;
using PPChat.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Services
{
    public class AuthService
    {
        private IMongoCollection<User> _users;

        public AuthService(IPPChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }


    }
}
