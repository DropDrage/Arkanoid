﻿namespace Event
{
    public interface IPublisher
    {
        void Invoke();
    }

    public interface IEventInvoker<T>
    {
        void Invoke(T data);
    }
}
