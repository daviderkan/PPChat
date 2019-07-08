using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Settings
{

    public class PPChatDatabaseSettings : IPPChatDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string MessagesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPPChatDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string MessagesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
