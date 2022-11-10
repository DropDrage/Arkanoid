using System;
using Managers;
using UnityEngine;

namespace Objects.Platform.Horizontal_Mover
{
    public class AccelerationMoveState : BaseHorizontalMoveState
    {
        private readonly float _acceleration;
        private readonly float _maxSpeed;

        protected readonly Rigidbody2D Rigidbody;

        private Vector2 _accelerationForce = Vector2.zero;
        public virtual HorizontalDirection HorizontalDirection
        {
            set => RecalculateAccelerationForce(value);
        }

        private void RecalculateAccelerationForce(HorizontalDirection direction)
        {
            var accelerationForceX = _accelerationForce.x;
            if (accelerationForceX == 0)
            {
                var directionValue = (int) direction;
                _accelerationForce = new Vector2(
                    (_acceleration * Rigidbody.mass + _acceleration * Rigidbody.drag) * directionValue, 0
                );
            }
            else if (accelerationForceX > 0 && direction == HorizontalDirection.Left
                || accelerationForceX < 0 && direction == HorizontalDirection.Right)
            {
                _accelerationForce.x *= -1;
            }
        }


        public AccelerationMoveState(IHorizontalMoverStateMachine stateMachine, float maxSpeed, float acceleration,
            Rigidbody2D rigidbody) : base(stateMachine)
        {
#if UNITY_EDITOR
            if (maxSpeed < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxSpeed), "Max speed must be greater positive");
            }
            if (acceleration < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(acceleration), acceleration, null);
            }
#endif

            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            Rigidbody = rigidbody;
        }


        public override void FixedUpdate()
        {
            Rigidbody.AddForce(_accelerationForce, ForceMode2D.Force);
            Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, _maxSpeed);
        }

        public override void OnMoveDirectionChanged(InputMoveDirection newDirection)
        {
            switch (newDirection)
            {
                case InputMoveDirection.Idle:
                    StateMachine.SetIdleState();
                    break;
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
