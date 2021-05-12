using eventBus.Events;

namespace eventBus
{
    public class TestBEvent : PubSubEvent<TestBEventArgs> { };
    public class TestBEventArgs : PubSubEventArgs<int> { }
}