using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class BallsManager : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;

        [Space]
        [Min(0f), SerializeField] private float ballStartVelocityOffsetAngle = 30f;
        [Min(0f), SerializeField] private float ballsMaxVelocityOffsetAngle = 180f;

        [SerializeField] private GameObject firstBall;

        private readonly List<GameObject> _balls = new List<GameObject>(1);

        private Transform _ballContainer;

        public bool IsBallLast => _balls.Count == 1;


        private void Awake()
        {
            _ballContainer = new GameObject("Ball Container").transform;
            _balls.Add(firstBall);
        }

        private void OnDestroy()
        {
            _balls.Clear();
        }


        public void AddBallsFromBall(int count, GameObject parentBall = null)
        {
#if UNITY_EDITOR
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, null);
            }
#endif

            var ball = parentBall != null ? parentBall : _balls[0];

            var ballPosition = ball.transform.position;

            var ballRigidbody = ball.GetComponent<Rigidbody2D>();
            var ballVelocity = ballRigidbody.velocity;
            var ballAngularVelocity = ballRigidbody.angularVelocity;

            var angleStep = ballStartVelocityOffsetAngle * count > ballsMaxVelocityOffsetAngle
                ? ballsMaxVelocityOffsetAngle / count
                : ballStartVelocityOffsetAngle;
            for (int i = 2, offsettedBallsCount = count + 2; i < offsettedBallsCount; i++)
            {
                var myAngle = angleStep * GetSwingingModifier(i);
                var velocity = Quaternion.AngleAxis(myAngle, Vector3.back) * ballVelocity;
                _balls.Add(CreateBall(ballPosition, velocity, ballAngularVelocity));
            }
        }

        private static int GetSwingingModifier(int i) => (i >> 1) * ((i & 1) == 0 ? 1 : -1);

        private GameObject CreateBall(Vector3 position, Vector2 velocity, float angularVelocity)
        {
            var ballObject = Instantiate(ballPrefab, position, Quaternion.identity, _ballContainer);
            var ballRigidbody = ballObject.GetComponent<Rigidbody2D>();
            ballRigidbody.velocity = velocity;
            ballRigidbody.angularVelocity = angularVelocity;

            return ballObject;
        }

        public void RemoveBall(GameObject ball)
        {
            _balls.Remove(ball);
        }
    }
}
