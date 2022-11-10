using Objects.Ball.Damage;
using Objects.Ball.Damage.Torque;
using UnityEngine;

namespace Objects.Ball.Torque_Power_Up
{
    public class TorquePowerUpChargedState : ITorquePowerUpMonitorState
    {
        private readonly float _duration;

        private readonly SpriteRenderer _renderer;
        private readonly TorquePowerUp _powerUp;

        private readonly IBallDamageCalculator _damageCalculator;
        private readonly ITorquePowerUpStateMachine _stateMachine;

        private readonly PowerUpTorqueDamageCalculator _torqueDamageCalculator;

        private float _timeLeft;


        public TorquePowerUpChargedState(ITorquePowerUpStateMachine stateMachine, float duration,
            SpriteRenderer renderer, TorquePowerUp powerUp, IBallDamageCalculator damageCalculator)
        {
            _duration = duration;
            _renderer = renderer;
            _powerUp = powerUp;
            _damageCalculator = damageCalculator;
            _stateMachine = stateMachine;

            _torqueDamageCalculator = new PowerUpTorqueDamageCalculator(powerUp.Damage);
        }


        public void OnEnterState()
        {
            _timeLeft = _duration;
            _renderer.color = Color.red;
            _powerUp.enabled = true;

            _damageCalculator.SetTorqueDamageCalculator(_torqueDamageCalculator);
        }

        public void UpdateCharge(float deltaTime)
        {
            _timeLeft -= deltaTime;

            if (_timeLeft <= 0)
            {
                _stateMachine.SetTorqueNotChargedState();
            }
        }

        public void OnExitState()
        {
            _damageCalculator.ResetTorqueDamageCalculator();
            _powerUp.enabled = false;
        }
    }
}
