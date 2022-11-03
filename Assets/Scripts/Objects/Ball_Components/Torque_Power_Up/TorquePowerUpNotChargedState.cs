﻿using UnityEngine;

namespace Objects.Ball_Components.Torque_Power_Up
{
    public class TorquePowerUpNotChargedState : ITorquePowerUpMonitorState
    {
        private readonly float _velocityForCharge;
        private readonly Color _torquePowerChargedColor;

        private readonly Rigidbody2D _rigidbody;
        private readonly SpriteRenderer _renderer;

        private readonly ITorquePowerUpStateMachine _stateMachine;


        public TorquePowerUpNotChargedState(float velocityForCharge, Color torquePowerChargedColor,
            Rigidbody2D rigidbody, SpriteRenderer renderer, ITorquePowerUpStateMachine stateMachine)
        {
            _velocityForCharge = velocityForCharge;
            _torquePowerChargedColor = torquePowerChargedColor;
            _rigidbody = rigidbody;
            _renderer = renderer;
            _stateMachine = stateMachine;
        }



        public void OnEnterState()
        {
        }


        public void UpdateCharge()
        {
            var torquePowerCharge = Mathf.Abs(_rigidbody.angularVelocity / _velocityForCharge);
            _renderer.color = Color.Lerp(Color.white, _torquePowerChargedColor, torquePowerCharge);

            if (torquePowerCharge > 1f)
            {
                _stateMachine.SetTorqueChargedState();
            }
        }

        public void OnExitState()
        {
        }
    }
}
