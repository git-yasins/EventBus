using eventbus;
using eventBus.Events;

namespace eventBus
{
   public class SubscriberA
    {
        public string Name { get; set; }
        public SubscriberA(string name)
        {
            Name = name;
            EventBus.Default.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
        }

        public void TeatAEventHandler(object sender, TestAEventArgs e)
        {
            System.Console.WriteLine($"{Name}:{e.Value}");
        }
    }
}