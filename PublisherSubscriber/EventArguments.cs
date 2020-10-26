using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublisherSubscriber
{
    public class EventArguments:EventArgs
    {
        public string Message { get; set; }
        public EventArguments(string Message)
        {
            this.Message = Message;
        }
    }
}