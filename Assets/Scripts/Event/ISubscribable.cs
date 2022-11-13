using System;

namespace Event
{
    public interface ISubscribable
    {
        void Subscribe(Action subscription);

        void Unsubscribe(Action subscription);
    }

    public interface ISubscribable<T>
    {
        void Subscribe(Action<T> subscription);

        void Unsubscribe(Action<T> subscription);
    }
}
