using UnityEngine;

namespace Objects
{
    public class BallThrower : MonoBehaviour
    {
        [Min(0), SerializeField] private float ballLaunchForce;

        [SerializeField] private TransformPositionsSynchronizer ballToPlatformSynchronizer;

        private Rigidbody2D _ball;
        private Rigidbody2D _platform;


        public void SetPlayer(Rigidbody2D ball, Rigidbody2D platform)
        {
            _ball = ball;
            _platform = platform;
        }

        public void Throw()
        {
            if (!ballToPlatformSynchronizer.enabled)
            {
                print("Ball has already been thrown");
                return;
            }

            ballToPlatformSynchronizer.Release();

            var ballStartForce = new Vector2(_platform.velocity.x, ballLaunchForce).normalized * ballLaunchForce;
            _ball.AddForce(ballStartForce, ForceMode2D.Impulse);
        }
    }
}
