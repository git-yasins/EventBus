using System.Threading.Tasks;
using eventbus;
using eventBus.Events;

namespace eventBus.Events
{
    public class TestAEventArgs : PubSubEventArgs<string> { }
    public class TestAEvent : PubSubEvent<TestAEventArgs>
    {
        public override void Publish(object sender, TestAEventArgs EventArgs)
        {
            lock (locker)
            {
                subscriptions.ForEach(action =>
                {
                    Task.Run(() => action(sender, EventArgs));
                });
            }
        }
    }
}