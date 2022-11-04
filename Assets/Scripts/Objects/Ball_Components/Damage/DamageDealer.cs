using UnityEngine;

namespace Objects.Ball_Components.Damage
{
    [RequireComponent(typeof(IDamageCalculator))]
    public class DamageDealer : MonoBehaviour
    {
        private IDamageCalculator _damageCalculator;


        private void Awake()
        {
            _damageCalculator = GetComponent<IDamageCalculator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.TryGetComponent<IDamageable>(out var damagable))
            {
                damagable.DealDamage(_damageCalculator.Damage);
            }
        }
    }
}
