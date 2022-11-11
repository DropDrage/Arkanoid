using UnityEngine;

namespace Objects.Ball
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BallModel))]
    public class OnBounceSoundPlayer : MonoBehaviour
    {
        [Space]
        [SerializeField] private AudioSource bounceSoundPlayer;

        private Rigidbody2D _rigidbody;

        private float _initialPitch;
        private float _initialHalfMass;
        private float _previousMass;


        private void Awake()
        {
            _initialPitch = bounceSoundPlayer.pitch;
            _rigidbody = GetComponent<BallModel>().Rigidbody;
            _initialHalfMass = _rigidbody.mass / 2;
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            UpdatePitchIfMassChanged();

            var otherGameObject = other.gameObject;
            PlayBounceSound(otherGameObject);
        }

        private void UpdatePitchIfMassChanged()
        {
            var mass = _rigidbody.mass;
            if (!Mathf.Approximately(_previousMass, mass))
            {
                bounceSoundPlayer.pitch = _initialPitch / (mass / 2 + _initialHalfMass);
                _previousMass = mass;
            }
        }

        private void PlayBounceSound(GameObject otherGameObject)
        {
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
