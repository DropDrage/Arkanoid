using UnityEngine;

namespace Objects
{
    [DisallowMultipleComponent]
    public class Ball : MonoBehaviour
    {
        [Min(0), SerializeField] private int damage;

        [Space]
        [SerializeField] private AudioSource jumpAudio;



        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherGameObject = other.gameObject;
            if (otherGameObject.TryGetComponent<IDamageable>(out var damagable))
            {
                damagable.DealDamage(damage);
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
