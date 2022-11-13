using System;
using System.Collections.Generic;

namespace Event
{
    public interface IEventPublisherProvider
    {
        IPublisher GetPublisher(string key);
    }

    public interface IEventSubscribableProvider
    {
        ISubscribable GetSubscribable(string key);
    }

    public class EventsPublisherHolder : IEventPublisherProvider, IEventSubscribableProvider, IDisposable
    {
        private readonly IDictionary<string, Event> Events = new Dictionary<string, Event>();


        public IPublisher GetPublisher(string key)
        {
            return GetEventOrCreate(key);
        }

        public ISubscribable GetSubscribable(string key)
        {
            return GetEventOrCreate(key);
        }

        private Event GetEventOrCreate(string key)
        {
            if (Events.TryGetValue(key, out var @event))
            {
                return @event;
            }

            Events.Add(key, new Event());
            return Events[key];
        }


        public void Dispose()
        {
            foreach (var @event in Events.Values)
            {
                @event.Dispose();
            }
        }
    }
}
