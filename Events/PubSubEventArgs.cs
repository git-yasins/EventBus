using System;

namespace eventBus.Events
{
    public abstract class PubSubEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
}