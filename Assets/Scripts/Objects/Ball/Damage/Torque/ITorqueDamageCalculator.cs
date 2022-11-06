using UnityEngine;

namespace Objects.Ball.Damage.Torque
{
    public interface ITorqueDamageCalculator
    {
        public float CalculateTorqueDamage(Rigidbody2D rigidbody);
    }
}
