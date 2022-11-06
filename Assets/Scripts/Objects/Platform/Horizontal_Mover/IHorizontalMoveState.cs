using Managers;

namespace Objects.Platform.Horizontal_Mover
{
    public interface IHorizontalMoveState
    {
        void FixedUpdate();

        void OnMoveDirectionChanged(InputMoveDirection newDirection);
    }
}
