using NaughtyAttributes;
using Objects.Ball.Damage;
using UnityEngine;

namespace Objects.Ball.Torque_Power_Up
{
    [RequireComponent(typeof(BallModel))]
    public class TorquePowerUpMonitor : MonoBehaviour, ITorquePowerUpStateMachine
    {
        [Min(0), SerializeField] private float velocityForCharge;
        [Min(0), SerializeField] private float duration;

        [Space]
        [ColorUsage(false), SerializeField] private Color torquePowerCharged;

        private TorquePowerUpNotChargedState _notChargedState;
        private TorquePowerUpChargedState _chargedState;
        private ITorquePowerUpMonitorState _currentState;


        private void Awake()
        {
            var ballModel = GetComponent<BallModel>();
            var rigidbody = ballModel.Rigidbody;
            var renderer = ballModel.Renderer;

            var powerUp = GetComponent<TorquePowerUp>();
            var damageCalculator = GetComponent<BallDamageCalculator>();

            _notChargedState =
                new TorquePowerUpNotChargedState(this, velocityForCharge, torquePowerCharged, rigidbody, renderer);
            _chargedState = new TorquePowerUpChargedState(this, duration, renderer, powerUp, damageCalculator);
        }

        private void Start()
        {
            ((ITorquePowerUpStateMachine) this).SetTorqueNotChargedState();
        }


        private void FixedUpdate()
        {
            _currentState.UpdateCharge(Time.fixedDeltaTime);
        }


        [Button("Set Not Charged State", EButtonEnableMode.Playmode)]
        void ITorquePowerUpStateMachine.SetTorqueNotChargedState()
        {
            ChangeState(_notChargedState);
        }

        [Button("Set Charged State", EButtonEnableMode.Playmode)]
        void ITorquePowerUpStateMachine.SetTorqueChargedState()
        {
            ChangeState(_chargedState);
        }

        private void ChangeState(ITorquePowerUpMonitorState newState)
        {
            _currentState?.OnExitState();
            _currentState = newState;
            _currentState.OnEnterState();
        }
    }
}
