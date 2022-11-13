using System.Collections.Generic;
using Objects.Ball;
using Objects.Bonus.Ball.Modifier;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Managers
{
    public class BallFactory : MonoBehaviour
    {
        private readonly List<BaseBallModifier> _modifiers = new List<BaseBallModifier>();

        [SerializeField] private GameObject prefab;

        private Transform _ballContainer;

        private IObjectResolver _diContainer;


        [Inject]
        private void Construct(IObjectResolver diContainer)
        {
            _diContainer = diContainer;
        }


        private void Awake()
        {
            _ballContainer = new GameObject("Ball Container").transform;
        }


        public BallModel CreateBall(Vector3 position)
        {
            var ballModel = _diContainer.Instantiate(prefab, position, Quaternion.identity, _ballContainer)
                .GetComponent<BallModel>();
            ApplyModifiers(ballModel);
            return ballModel;
        }

        public BallModel CreateBall(Vector3 position, Vector2 velocity, float angularVelocity)
        {
            var ballModel = CreateBall(position);
            var ballRigidbody = ballModel.Rigidbody;
            ballRigidbody.velocity = velocity;
            ballRigidbody.angularVelocity = angularVelocity;

            return ballModel;
        }

        private void ApplyModifiers(BallModel ball)
        {
            for (int i = 0, modifiersCount = _modifiers.Count; i < modifiersCount; i++)
            {
                _modifiers[i].Apply(ball);
            }
        }


        public void AddModifier(BaseBallModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void ClearModifiers()
        {
            _modifiers.Clear();
        }
    }
}
