using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace eventBus.Events
{
    public class EventBus
    {
        private static EventBus _default;
        private static readonly object locker = new object();
        private Dictionary<Type, EventBase> eventDic = new Dictionary<Type, EventBase>();

        //single instance
        public static EventBus Default
        {
            get
            {
                if (_default == null)
                {
                    lock (locker)
                    {
                        if (_default == null)
                        {
                            _default = new EventBus();
                        }
                    }
                }
                return _default;
            }
        }

        public EventBus()
        {
            Type type = typeof(EventBase);
            Type typePubSub = typeof(PubSubEvent<>);
            Assembly assembly = Assembly.GetAssembly(type);
            List<Type> typeList = assembly.GetTypes().Where(x => x != type && x != typePubSub && x.IsAssignableFrom(x)).ToList();
            foreach (var item in typeList)
            {
                EventBase eventBase = (EventBase)assembly.CreateInstance(item.FullName);
                eventDic.Add(item, eventBase);
            }
        }

        /// <summary>
        /// get event instance
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        public TEvent GetEvent<TEvent>() where TEvent : EventBase
        {
            return (TEvent)eventDic[typeof(TEvent)];
        }

        public void AddEvent<TEvent>() where TEvent : EventBase, new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (!eventDic.ContainsKey(type))
                {
                    eventDic.Add(type, new TEvent());
                }
            }
        }

        public void RemoveEvent<TEvent>() where TEvent : EventBase, new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (!eventDic.ContainsKey(type))
                {
                    eventDic.Remove(type);
                }
            }
        }
    }
}