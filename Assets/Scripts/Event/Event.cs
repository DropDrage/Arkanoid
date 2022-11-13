using System;

namespace Event
{
    public class Event : IPublisher, ISubscribable, IDisposable
    {
        private event Action _event;


        public void Invoke()
        {
            _event?.Invoke();
        }


        public void Subscribe(Action subscription)
        {
            _event += subscription;
        }

        public void Unsubscribe(Action subscription)
        {
            _event -= subscription;
        }


        public void Dispose()
        {
            _event = null;
        }
    }
}
