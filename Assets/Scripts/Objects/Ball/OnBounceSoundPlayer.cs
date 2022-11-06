using UnityEngine;

namespace Objects.Ball
{
    [DisallowMultipleComponent]
    public class OnBounceSoundPlayer : MonoBehaviour
    {
        [Space]
        [SerializeField] private AudioSource bounceSoundPlayer;


        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherGameObject = other.gameObject;

            if (otherGameObject.TryGetComponent<CustomCollideSoundOwner>(out var customCollideSoundOwner))
            {
                bounceSoundPlayer.PlayOneShot(customCollideSoundOwner.CollideSound);
            }
            else
            {
                bounceSoundPlayer.Play();
            }
        }
    }
}
