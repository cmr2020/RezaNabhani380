﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyRezaNabhani.DomainClasses.Chat
{
    public class ChatMessage
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset SendAt { get; set; }

    }
}
