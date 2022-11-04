using UnityEngine;

namespace Objects.Ball_Components.Damage.Torque
{
    public interface ITorqueDamageCalculator
    {
        public float CalculateTorqueDamage(Rigidbody2D rigidbody);
    }
}
