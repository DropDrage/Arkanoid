using Managers;
using Objects.Bonus;
using UnityEngine;
using VContainer;

namespace Objects.Platform
{
    public class BonusUser : MonoBehaviour
    {
        private OneShotSoundsPlayer _oneShotSoundsPlayer;


        [Inject]
        private void Construct(OneShotSoundsPlayer oneShotSoundsPlayer)
        {
            _oneShotSoundsPlayer = oneShotSoundsPlayer;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<BasePlatformBonus>(out var platformBonus))
            {
                platformBonus.Use(gameObject);
                _oneShotSoundsPlayer.PlayPowerUpActivationSound();
            }
        }
    }
}
