using NaughtyAttributes;
using UnityEngine;

namespace Objects.Ball_Components.Torque_Power_Up
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TorquePowerUpMonitor : MonoBehaviour, ITorquePowerUpStateMachine
    {
        [Min(0), SerializeField] private float velocityForCharge;
        [Min(0), SerializeField] private float duration;

        [ColorUsage(false), SerializeField] private Color torquePowerCharged;
        [SerializeField] private SpriteRenderer renderer;

        private Rigidbody2D _rigidbody;
        private DamageCalculator _damageCalculator;

        private TorquePowerUpNotChargedState _notChargedState;
        private TorquePowerUpChargedState _chargedState;
        private ITorquePowerUpMonitorState _currentState;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            var powerUp = GetComponent<TorquePowerUp>();
            _damageCalculator = GetComponent<DamageCalculator>();

            _notChargedState =
                new TorquePowerUpNotChargedState(velocityForCharge, torquePowerCharged, _rigidbody, renderer, this);
            _chargedState = new TorquePowerUpChargedState(duration, renderer, powerUp, _damageCalculator, this);
        }

        private void Start()
        {
            ((ITorquePowerUpStateMachine) this).SetTorqueNotChargedState();
        }


        private void FixedUpdate()
        {
            _currentState.UpdateCharge();
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
