using Managers;
using UnityEngine;
using VContainer;

namespace Objects.Platform.Horizontal_Mover
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class HorizontalMoverOnInput : MonoBehaviour, IHorizontalMoverStateMachine
    {
        [Min(0), SerializeField] private float maxSpeed;
        [Min(0), SerializeField] private float accelerationForce;

        private IdleHorizontalMoveState _idleState;
        private AccelerationMoveState _accelerationState;
        private IHorizontalMoveState _currentState;


        [Inject]
        private void Construct(InputHandler inputHandler)
        {
            inputHandler.AddMoveDirectionChangedListener(ChangeState);
        }

        private void ChangeState(InputMoveDirection moveDirection)
        {
            _currentState.OnMoveDirectionChanged(moveDirection);
        }


        private void Awake()
        {
            var body = GetComponent<Rigidbody2D>();

            _idleState = new IdleHorizontalMoveState(this);
            _accelerationState = new AccelerationMoveState(this, maxSpeed, accelerationForce, body);
        }

        private void Start()
        {
            ((IHorizontalMoverStateMachine) this).SetIdleState();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }


        void IHorizontalMoverStateMachine.SetIdleState()
        {
            ChangeState(_idleState);
        }

        void IHorizontalMoverStateMachine.SetAccelerationState(HorizontalDirection direction)
        {
            ChangeState(_accelerationState);
            _accelerationState.HorizontalDirection = direction;
        }

        private void ChangeState(IHorizontalMoveState newState)
        {
            _currentState = newState;
        }
    }
}
