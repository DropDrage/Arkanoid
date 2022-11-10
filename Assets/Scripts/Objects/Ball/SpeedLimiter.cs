using UnityEngine;

namespace Objects.Ball
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BallModel))]
    public class SpeedLimiter : MonoBehaviour
    {
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        private Rigidbody2D _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<BallModel>().Rigidbody;
        }

        private void OnCollisionExit2D()
        {
            var clampedVelocity = Vector2.ClampMagnitude(_rigidbody.velocity, maxSpeed);
            if (clampedVelocity.magnitude < minSpeed)
            {
                clampedVelocity = clampedVelocity.normalized * minSpeed;
            }

            _rigidbody.velocity = clampedVelocity;
        }
    }
}
