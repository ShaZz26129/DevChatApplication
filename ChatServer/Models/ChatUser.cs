using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    public class ChatUser
    {
        public string ConnectionId { get; set; }
        private string chatUsername;
    private string currentUserName;

    public string ChatUsername
    {
        get { return chatUsername; }
        set
        {
            chatUsername = value;
            if (!string.IsNullOrEmpty(value))
            {
                currentUserName = value.Split('_')[0];
            }
            else
            {
                currentUserName = null;
            }
        }
    }

    public string CurrentUserName
    {
        get { return currentUserName; }
    }
        public DateTime ActionTime { get; set; }
       
    }
}
