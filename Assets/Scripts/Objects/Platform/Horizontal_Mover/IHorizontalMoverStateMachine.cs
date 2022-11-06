namespace Objects.Platform.Horizontal_Mover
{
    public interface IHorizontalMoverStateMachine
    {
        void SetIdleState();
        void SetAccelerationState(HorizontalDirection direction);
    }
}
