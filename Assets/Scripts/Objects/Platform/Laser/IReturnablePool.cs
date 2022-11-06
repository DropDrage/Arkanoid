namespace Objects.Platform.Laser
{
    public interface IReturnablePool<T> where T : class
    {
        void Return(T item);
    }
}
