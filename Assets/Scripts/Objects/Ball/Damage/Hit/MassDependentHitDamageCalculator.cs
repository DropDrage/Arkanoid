using UnityEngine;

namespace Objects.Ball.Damage.Hit
{
    public class MassDependentHitDamageCalculator : MonoBehaviour, IHitDamageCalculator
    {
        [Min(0), SerializeField] private float baseDamage;

        public float CalculateDamage(Rigidbody2D rigidbody) => baseDamage * rigidbody.mass;
    }
}
