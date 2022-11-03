using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [Header("Brick")]
        [SerializeField] private AudioClip brickDestroy;

        [Header("Torque Power Up")]
        [SerializeField] private AudioClip powerUpActivationSound;
        [SerializeField] private AudioClip powerUpDisableSound;

        private AudioSource _source;


        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }


        public void PlayBrickDestroySound()
        {
            _source.PlayOneShot(brickDestroy);
        }


        public void PlayPowerUpActivationSound()
        {
            _source.PlayOneShot(powerUpActivationSound);
        }

        public void PlayPowerUpDeactivationSound()
        {
            _source.PlayOneShot(powerUpDisableSound);
        }
    }
}
