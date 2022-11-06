using System;
using Managers;

namespace Objects.Platform.Horizontal_Mover
{
    public class IdleHorizontalMoveState : BaseHorizontalMoveState
    {
        public IdleHorizontalMoveState(IHorizontalMoverStateMachine stateMachine) : base(stateMachine)
        {
        }


        public override void FixedUpdate()
        {
        }

        public override void OnMoveDirectionChanged(InputMoveDirection newDirection)
        {
            switch (newDirection)
            {
                case InputMoveDirection.Idle: break;
                case InputMoveDirection.Left:
                    StateMachine.SetAccelerationState(HorizontalDirection.Left);
                    break;
                case InputMoveDirection.Right:
                    StateMachine.SetAccelerationState(HorizontalDirection.Right);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(newDirection), newDirection, null);
            }
        }
    }
}
