using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class OneShotSoundsPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip brickDestroy;
        [SerializeField] private AudioClip bonusUseSound;

        [Header("Torque Power Up")]
        [SerializeField] private AudioClip torquePowerUpActivationSound;
        [SerializeField] private AudioClip torquePowerUpDisableSound;

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
            _source.PlayOneShot(torquePowerUpActivationSound);
        }

        public void PlayPowerUpDeactivationSound()
        {
            _source.PlayOneShot(torquePowerUpDisableSound);
        }


        public void PlayBonuseUseSound()
        {
            _source.PlayOneShot(bonusUseSound);
        }
    }
}
