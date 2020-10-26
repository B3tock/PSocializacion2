using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublisherSubscriber
{
    public class Subscriber
    {
        public void Subscribe(Publisher pub) {
            pub.myEvent += Update;
        }
        public void UnSubscribe(Publisher pub){
            pub.myEvent -= Update;
        }
        public void Update(object sender, EventArguments args){
            Publisher pub = (Publisher)sender;
            //Console.WriteLine(pub.Name + " send a message: " + args.Message);
        }
    }
}