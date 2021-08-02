using Microsoft.AspNetCore.SignalR;
using MyRezaNabhani.DomainClasses.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRezaNabhani.Web
{
    public class ChatHub:Hub
    {

        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.Now
            };


            await Clients.All.SendAsync("ReciveMessage", message.SenderName, message.SendAt, message.Text);

        }

    }
}
