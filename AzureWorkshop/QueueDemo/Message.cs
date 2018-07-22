using System;

namespace AzureWorkshop.QueueDemo
{
    // kann verwendet werden, um als Queue Message verschickt zu werden
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
