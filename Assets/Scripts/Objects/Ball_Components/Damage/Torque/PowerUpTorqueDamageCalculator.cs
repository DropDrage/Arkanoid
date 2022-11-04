using UnityEngine;

namespace Objects.Ball_Components.Damage.Torque
{
    public class PowerUpTorqueDamageCalculator : ITorqueDamageCalculator
    {
        private readonly float _damage;


        public PowerUpTorqueDamageCalculator(float damage)
        {
            _damage = damage;
        }


        public float CalculateTorqueDamage(Rigidbody2D rigidbody) => _damage;
    }
}
