﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesModule.DTOs
{
    public class SendMessageRequest
    {
        [Required]
        public int ReceiverId { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }
    }
}
