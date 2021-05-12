using eventbus;
using eventBus.Events;

namespace eventBus
{
    public class SubscriberB
    {
        public string Name { get; set; }
        public SubscriberB(string name)
        {
            Name = name;
            EventBus.Default.GetEvent<TestBEvent>().Subscribe(TeatBEventHandler);
        }

        public void Unsubscribe_TeatEvent() => EventBus.Default.GetEvent<TestBEvent>().Unsubscribe(TeatBEventHandler);

        public void TeatBEventHandler(object sender, TestBEventArgs e)
        {
            System.Console.WriteLine($"{Name}:{e.Value}");
        }
    }
}