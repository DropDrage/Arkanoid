using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip brickHit;
        [SerializeField] private AudioClip brickDestroy;
        
        private AudioSource _source;


        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }


        public void PlayBrickHitSound()
        {
            _source.PlayOneShot(brickHit);
        }

        public void PlayBrickDestroySound()
        {
            _source.PlayOneShot(brickDestroy);
        }
    }
}
