﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Message
    {
        public int MessageId { get; set; }
        
        public string Content { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int SenderId { get; set; }

        public User Sender { get; set; }

        public int ReceiverId { get; set; }

        public User Receiver { get; set; } 

        public DateTime Time { get; set; } 

    }
}
