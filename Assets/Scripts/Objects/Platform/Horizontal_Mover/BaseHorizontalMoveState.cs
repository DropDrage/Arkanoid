using Managers;

namespace Objects.Platform.Horizontal_Mover
{
    public abstract class BaseHorizontalMoveState
    {
        protected readonly IHorizontalMoverStateMachine StateMachine;


        protected BaseHorizontalMoveState(IHorizontalMoverStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }


        public abstract void FixedUpdate();
        public abstract void OnMoveDirectionChanged(InputMoveDirection newDirection);
    }
}
