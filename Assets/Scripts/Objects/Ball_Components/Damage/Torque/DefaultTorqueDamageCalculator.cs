using UnityEngine;

namespace Objects.Ball_Components.Damage.Torque
{
    public class DefaultTorqueDamageCalculator : MonoBehaviour, ITorqueDamageCalculator
    {
        [Min(0f), SerializeField] private float maxTorqueDamage;
        [Min(0.001f), SerializeField] private float maxAngularVelocity;


        public float CalculateTorqueDamage(Rigidbody2D rigidbody) =>
            Mathf.Clamp01(Mathf.Abs(rigidbody.angularVelocity) / maxAngularVelocity) * maxTorqueDamage;
    }
}
