using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace PublisherSubscriber
{
    public class Subscriber2
    {
        public Subscriber2()
        { 

        }
        public string[] topics = new string[2];
        public Queue<Message> myMessages = new Queue<Message>();
        public void listen (string newTopic, int index)
        {
            topics[index] = newTopic;
        }

        public void Print()
        {
            for (int i=0; i < topics.Length;i++ )
            {
                while (myMessages.Count !=0)
                {
                    Message newMessage = myMessages.Dequeue();
                    //WriteLine("Topic: " + newMessage.topic + "\n")
                }
            }
        }

    }
}