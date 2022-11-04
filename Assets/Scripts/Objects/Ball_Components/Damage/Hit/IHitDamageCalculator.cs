using UnityEngine;

namespace Objects.Ball_Components.Damage.Hit
{
    public interface IHitDamageCalculator
    {
        public float CalculateDamage(Rigidbody2D rigidbody);
    }
}
