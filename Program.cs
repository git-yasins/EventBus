using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using eventBus.Events;
using eventBus;

namespace eventbus
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            SubscriberA subscriberA = new SubscriberA("subscriberA");
            SubscriberB subscriberB = new SubscriberB("subscriberB");
            SubscriberB subscriberB1 = new SubscriberB("subscriberB1");

            publisher.PublishTeatAEvent("test");
            publisher.PublishTeatBEvent(123);

            subscriberB1.Unsubscribe_TeatEvent();
            publisher.PublishTeatBEvent(12345);
            Console.ReadKey();
        }
    }
}
