using UnityEngine;

namespace Objects.Ball_Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DamageCalculator))]
    public class Ball : MonoBehaviour
    {
        [Space]
        [SerializeField] private AudioSource jumpAudio;

        private DamageCalculator _damageCalculator;


        private void Awake()
        {
            _damageCalculator = GetComponent<DamageCalculator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.TryGetComponent<IDamageable>(out var damagable))
            {
                damagable.DealDamage(_damageCalculator.Damage);
            }

            if (otherGameObject.TryGetComponent<CustomCollideSoundOwner>(out var customCollideSoundOwner))
            {
                jumpAudio.PlayOneShot(customCollideSoundOwner.CollideSound);
            }
            else
            {
                jumpAudio.Play();
            }
        }
    }
}
