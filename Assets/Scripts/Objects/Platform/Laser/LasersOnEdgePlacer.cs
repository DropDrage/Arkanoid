using UnityEngine;

namespace Objects.Platform.Laser
{
    public class LasersOnEdgePlacer : MonoBehaviour
    {
        [SerializeField] private GameObject leftGun;
        [SerializeField] private GameObject rightGun;

        [SerializeField] private Vector2 gunOffset;

        private PlatformResizer _resizer;


        public void InitWithPlatform(GameObject platform)
        {
            _resizer = platform.GetComponent<PlatformResizer>();
            ChangeGunsPosition(_resizer.CurrentWidth);
            _resizer.SizeChanged += ChangeGunsPosition;

            leftGun.SetActive(true);
            rightGun.SetActive(true);
        }

        private void ChangeGunsPosition(float platformWidth)
        {
            var halfPlatformWidth = platformWidth / 2;
            leftGun.transform.localPosition = new Vector2(-halfPlatformWidth + gunOffset.x, gunOffset.y);
            rightGun.transform.localPosition = new Vector2(halfPlatformWidth - gunOffset.x, gunOffset.y);
        }

        private void OnDestroy()
        {
            _resizer.SizeChanged -= ChangeGunsPosition;
        }
    }
}
