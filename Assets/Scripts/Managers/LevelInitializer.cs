using Objects;
using Objects.Ball;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Managers
{
    public class LevelInitializer : MonoBehaviour
    {
        [Space]
        [SerializeField] private BallsManager ballsManager;
        [SerializeField] private GameObject platformPrefab;

        [Space]
        [SerializeField] private BallThrower ballThrower;
        [SerializeField] private TransformPositionsSynchronizer transformsSynchronizer;

        private IObjectResolver _diContainer;


        [Inject]
        private void Construct(IObjectResolver diContainer)
        {
            _diContainer = diContainer;
        }


        public GameObject SpawnPlayer()
        {
            var ballObject = SpawnBall();
            var platformObject = SpawnPlatform();

            var ballRigidbody = ballObject.GetComponent<BallModel>().Rigidbody;
            var platformRigidbody = platformObject.GetComponent<Rigidbody2D>();

            transformsSynchronizer.Connect(platformObject.transform, ballObject.transform);
            ballThrower.SetPlayer(ballRigidbody, platformRigidbody);

            return platformObject;
        }

        private GameObject SpawnBall() => ballsManager.SpawnBall();

        private GameObject SpawnPlatform() => _diContainer.Instantiate(platformPrefab);
    }
}
