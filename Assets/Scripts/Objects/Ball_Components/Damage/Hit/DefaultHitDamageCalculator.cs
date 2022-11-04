using UnityEngine;

namespace Objects.Ball_Components.Damage.Hit
{
    public class DefaultHitDamageCalculator : MonoBehaviour, IHitDamageCalculator
    {
        [Min(0), SerializeField] private float baseDamage;

        public float CalculateDamage(Rigidbody2D _) => baseDamage;
    }
}
