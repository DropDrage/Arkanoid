using Managers;
using Objects.Bonus.Ball;
using Objects.Bonus.Platform;
using UnityEngine;
using VContainer;

namespace Objects.Platform
{
    public class BonusUser : MonoBehaviour
    {
        private OneShotSoundsPlayer _oneShotSoundsPlayer;
        private BallsManager _ballsManager;


        [Inject]
        private void Construct(OneShotSoundsPlayer oneShotSoundsPlayer, BallsManager ballsManager)
        {
            _oneShotSoundsPlayer = oneShotSoundsPlayer;
            _ballsManager = ballsManager;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<BasePlatformBonus>(out var platformBonus))
            {
                platformBonus.Use(gameObject);
                _oneShotSoundsPlayer.PlayPowerUpActivationSound();
            }
            else if (other.TryGetComponent<BaseBallBonus>(out var ballBonus))
            {
                ballBonus.Use(_ballsManager);
                _oneShotSoundsPlayer.PlayPowerUpActivationSound();
            }
        }
    }
}
