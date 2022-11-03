using UnityEngine;

namespace Objects.Ball_Components.Torque_Power_Up
{
    public class TorquePowerUpChargedState : ITorquePowerUpMonitorState
    {
        private readonly float _duration;
        private readonly SpriteRenderer _renderer;
        private readonly TorquePowerUp _powerUp;
        private readonly DamageCalculator _damageCalculator;
        private readonly ITorquePowerUpStateMachine _stateMachine;

        private float _timeLeft;


        public TorquePowerUpChargedState(float duration, SpriteRenderer renderer, TorquePowerUp powerUp,
            DamageCalculator damageCalculator, ITorquePowerUpStateMachine stateMachine)
        {
            _duration = duration;
            _renderer = renderer;
            _powerUp = powerUp;
            _damageCalculator = damageCalculator;
            _stateMachine = stateMachine;
        }


        public void OnEnterState()
        {
            _timeLeft = _duration;
            _renderer.color = Color.red;
            _powerUp.enabled = true;

            _damageCalculator.ChangeTorqueDamageCalculator(CalculateTorqueDamage);
        }

        private float CalculateTorqueDamage(Rigidbody2D _) => _powerUp.Damage;

        public void UpdateCharge()
        {
            _timeLeft -= Time.fixedDeltaTime;

            if (_timeLeft <= 0)
            {
                _stateMachine.SetTorqueNotChargedState();
            }
        }

        public void OnExitState()
        {
            _powerUp.enabled = false;
        }
    }
}
