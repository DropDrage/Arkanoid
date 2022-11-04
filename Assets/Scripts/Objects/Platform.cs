using Managers;
using UnityEngine;

namespace Objects
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Platform : MonoBehaviour
    {
        [Min(0), SerializeField] private float speed;
        [Min(0), SerializeField] private float ballLaunchForce;

        [SerializeField] private InputHandler inputHandler;

        [SerializeField] private FixedJoint2D ballJoint;
        private Rigidbody2D _body;


        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            _body.velocity = new Vector2(speed * inputHandler.MoveDirection, 0);
        }


        public void ThrowBall()
        {
            if (ballJoint == null) //ToDo manual listener unsubscribe?
            {
                return;
            }

            var ball = ballJoint.connectedBody;
            Destroy(ballJoint);

            var ballStartForce = new Vector2(_body.velocity.x, ballLaunchForce).normalized * ballLaunchForce;
            ball.AddForce(ballStartForce, ForceMode2D.Impulse);
        }
    }
}
