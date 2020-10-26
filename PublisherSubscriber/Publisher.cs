using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublisherSubscriber
{
    public class Publisher
    {
        public string Codigo { get; set; }
        public string URL { get; set; }

        public event EventHandler<EventArguments> myEvent;

        public void Notify(string message)
        {
            EventArguments args = new EventArguments(message);
            
            if (myEvent != null)
            {
                myEvent(this, args);
            }
        }
    }
}