using UnityEngine;

namespace Objects
{
    public class BallThrower : MonoBehaviour
    {
        [Min(0), SerializeField] private float ballLaunchForce;

        [SerializeField] private TransformPositionsSynchronizer ballToPlatformSynchronizer;

        [Space]
        [SerializeField] private Rigidbody2D platformRigidbody;
        [SerializeField] private Rigidbody2D ballRigidbody;


        public void Throw()
        {
            if (ballToPlatformSynchronizer == null) //ToDo manual listener unsubscribe?
            {
                print("No positions synchronizer");
                return;
            }

            ballToPlatformSynchronizer.Release();

            var ballStartForce =
                new Vector2(platformRigidbody.velocity.x, ballLaunchForce).normalized * ballLaunchForce;
            ballRigidbody.AddForce(ballStartForce, ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }
}
