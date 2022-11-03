using System;
using UnityEngine;

namespace Objects.Ball_Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class DamageCalculator : MonoBehaviour
    {
        [Min(0), SerializeField] private float baseDamage;

        [Header("Torque")]
        [Min(0.001f), SerializeField] private float maxTorqueDamage;
        [Min(0f), SerializeField] private float maxAngularVelocity;

        private Func<Rigidbody2D, float> _defaultTorqueDamageCalculator;
        private Func<Rigidbody2D, float> _calculateTorqueDamage;
        private Rigidbody2D _rigidbody;

        public float Damage => baseDamage + TorqueDamage;

        private float TorqueDamage => _calculateTorqueDamage(_rigidbody);


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _defaultTorqueDamageCalculator = rigidbody =>
                Mathf.Clamp01(Mathf.Abs(rigidbody.angularVelocity) / maxAngularVelocity) * maxTorqueDamage;
        }

        private void Start()
        {
            ResetTorqueDamageCalculator();
        }


        public void ChangeTorqueDamageCalculator(Func<Rigidbody2D, float> newTorqueDamageCalculator)
        {
            _calculateTorqueDamage = newTorqueDamageCalculator;
        }

        public void ResetTorqueDamageCalculator()
        {
            _calculateTorqueDamage = _defaultTorqueDamageCalculator;
        }
    }
}
