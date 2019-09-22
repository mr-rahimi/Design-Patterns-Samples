using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Visitor
{
    public interface IMessage
    {
        void Accept(IMessageSender sender);
    }
    public interface IMessageSender
    {
        void Send(SMSMessage message);
        void Send(EmailMessage message);
    }

    public class SMSMessage : IMessage
    {
        public string MobileNumber { get; set; }
        public string Message { get; set; }
        public void Accept(IMessageSender sender)
        {
            sender.Send(this);
        }
    }
    public class EmailMessage : IMessage
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public void Accept(IMessageSender sender)
        {
            sender.Send(this);
        }
    }

    public class WsSender : IMessageSender
    {
        public void Send(EmailMessage message)
        {
            Console.WriteLine("sending email by web service");
            Console.WriteLine($"email : {message.EmailAddress}");
            Console.WriteLine($"subject : {message.Subject}");
            Console.WriteLine($"message : {message.Message}");
        }
        public void Send(SMSMessage message)
        {
            Console.WriteLine("sending sms by web service");
            Console.WriteLine($"mobile number : {message.MobileNumber}");
            Console.WriteLine($"message : {message.Message}");
        }
    }
    public class ApiSender : IMessageSender
    {
        public void Send(EmailMessage message)
        {
            Console.WriteLine("send email by api");
        }
        public void Send(SMSMessage message)
        {
            Console.WriteLine("send sms by api");
        }
    }

    public class NotificationSender<T> where T : IMessageSender, new()
    {
        public void Send<K>(K message) where K : IMessage, new()
        {
            message.Accept(new T());
        }
    }

    public class Using
    {
        public static void Use()
        {
            var sender = new NotificationSender<WsSender>();
            sender.Send<EmailMessage>(new EmailMessage()
            {
                EmailAddress = "mr_rahimi@live.com",
                Subject = "Greating",
                Message = "Hello"
            });
            // Wait for user

            Console.ReadKey();
        }
    }
}
