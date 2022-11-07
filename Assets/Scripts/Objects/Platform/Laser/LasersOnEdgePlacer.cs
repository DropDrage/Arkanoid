using UnityEngine;

namespace Objects.Platform.Laser
{
    [RequireComponent(typeof(LaserShootStarter))]
    public class LasersOnEdgePlacer : MonoBehaviour
    {
        [SerializeField] private Transform leftGun;
        [SerializeField] private Transform rightGun;

        [Space]
        [SerializeField] private Vector2 gunOffset;

        private PlatformResizer _resizer;


        public void InitWithPlatform(GameObject platform)
        {
            _resizer = platform.GetComponent<PlatformResizer>();
            ChangeGunsPosition(_resizer.CurrentWidth);
            _resizer.SizeChanged += ChangeGunsPosition;

            GetComponent<LaserShootStarter>().StartShoot();
        }

        private void ChangeGunsPosition(float platformWidth)
        {
            var halfPlatformWidth = platformWidth / 2;
            leftGun.localPosition = new Vector2(-halfPlatformWidth + gunOffset.x, gunOffset.y);
            rightGun.localPosition = new Vector2(halfPlatformWidth - gunOffset.x, gunOffset.y);
        }

        private void OnDestroy()
        {
            _resizer.SizeChanged -= ChangeGunsPosition;
        }
    }
}
