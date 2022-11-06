using UnityEngine;

namespace Objects.Ball.Damage.Hit
{
    public interface IHitDamageCalculator
    {
        public float CalculateDamage(Rigidbody2D rigidbody);
    }
}
