﻿using System;
using System.Collections.Generic;
using Objects.Ball;
using Objects.Bonus.Modifier;
using UnityEngine;

namespace Managers
{
    public class BallsManager : MonoBehaviour
    {
        [SerializeField] private BallFactory ballFactory;

        [Space]
        [Min(0f), SerializeField] private float ballStartVelocityOffsetAngle = 30f;
        [Min(0f), SerializeField] private float ballsMaxVelocityOffsetAngle = 180f;

        [SerializeField] private BallModel firstBall;

        private readonly List<BallModel> _balls = new List<BallModel>(1);

        private Transform _ballContainer;

        public bool IsBallLast => _balls.Count == 1;


        private void Awake()
        {
            _balls.Add(firstBall);
        }

        private void OnDestroy()
        {
            _balls.Clear();
        }


        public void AddBallsFromBall(int count, BallModel parentBall = null)
        {
#if UNITY_EDITOR
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, null);
            }
#endif
            if (_balls.Count == 0)
            {
                return;
            }

            var primaryBall = parentBall != null ? parentBall : _balls[0];

            var ballPosition = primaryBall.transform.position;

            var ballRigidbody = primaryBall.Rigidbody;
            var ballVelocity = ballRigidbody.velocity;
            var ballAngularVelocity = ballRigidbody.angularVelocity;

            var angleStep = ballStartVelocityOffsetAngle * count > ballsMaxVelocityOffsetAngle
                ? ballsMaxVelocityOffsetAngle / count
                : ballStartVelocityOffsetAngle;
            for (int i = 2, offsettedBallsCount = count + 2; i < offsettedBallsCount; i++)
            {
                var myAngle = angleStep * GetSwingingModifier(i);
                var velocity = Quaternion.AngleAxis(myAngle, Vector3.back) * ballVelocity;
                var newBallObject = ballFactory.CreateBall(ballPosition, velocity, ballAngularVelocity);
                _balls.Add(newBallObject);
            }
        }

        private static int GetSwingingModifier(int i) => (i >> 1) * ((i & 1) == 0 ? 1 : -1);


        public void RemoveBall(GameObject ball)
        {
            _balls.Remove(ball.GetComponent<BallModel>());
            Destroy(ball);
        }


        public void AddModifier(BaseBallModifier modifier)
        {
            for (var i = 0; i < _balls.Count; i++)
            {
                modifier.Apply(_balls[i]);
            }

            ballFactory.AddModifier(modifier);
        }
    }
}
