using Managers;

namespace Objects.Platform.Horizontal_Mover
{
    public abstract class BaseHorizontalMoveState : IHorizontalMoveState
    {
        protected readonly IHorizontalMoverStateMachine StateMachine;
        private IHorizontalMoveState _horizontalMoveStateImplementation;

        protected BaseHorizontalMoveState(IHorizontalMoverStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }


        public abstract void FixedUpdate();
        public abstract void OnMoveDirectionChanged(InputMoveDirection newDirection);
    }
}
