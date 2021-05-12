using System;
using System.Collections.Generic;

namespace eventBus.Events
{
    public abstract class PubSubEvent<T> : EventBase where T : EventArgs
    {
        protected static readonly object locker = new object();

        protected readonly List<Action<object, T>> subscriptions = new List<Action<object, T>>();

        public void Subscribe(Action<object, T> eventHandler)
        {
            lock (locker)
            {
                if (!subscriptions.Contains(eventHandler))
                {
                    subscriptions.Add(eventHandler);
                }
            }
        }

        public void Unsubscribe(Action<object, T> eventHandler)
        {
            lock (locker)
            {
                if (!subscriptions.Contains(eventHandler))
                {
                    subscriptions.Remove(eventHandler);
                }
            }
        }

        /// <summary>
        /// exec action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="EventArgs"></param>
        public virtual void Publish(object sender, T EventArgs)
        {
            lock (locker)
            {
                for (var i = 0; i < subscriptions.Count; i++)
                {
                    subscriptions[i](sender, EventArgs);
                }
            }
        }
    }
}