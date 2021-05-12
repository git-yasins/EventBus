using eventbus;
using eventBus.Events;

namespace eventBus
{
    public class Publisher
    {
        public void PublishTeatAEvent(string value)
        {
            EventBus.Default.GetEvent<TestAEvent>().Publish(this, new TestAEventArgs() { Value = value });
        }

        public void PublishTeatBEvent(int value)
        {
            EventBus.Default.GetEvent<TestBEvent>().Publish(this, new TestBEventArgs() { Value = value });
        }
    }
}