using Event;
using UnityEngine;
using VContainer;

namespace Managers.Level
{
    [RequireComponent(typeof(BlocksSpawner), typeof(PlayerSpawner))]
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private PlayerSpawner _playerSpawner;
        private BlocksSpawner _blocksSpawner;
        private GameObject _blocks;

        private LevelProvider _levelProvider;
        private IPublisher _deinitializeEvent;


        [Inject]
        private void Construct(LevelProvider levelProvider, IEventPublisherProvider eventsPublisherHolder)
        {
            _levelProvider = levelProvider;
            _deinitializeEvent = eventsPublisherHolder.GetPublisher(EventKeys.Deinitialize);
        }


        private void Awake()
        {
            _playerSpawner = GetComponent<PlayerSpawner>();
            _blocksSpawner = GetComponent<BlocksSpawner>();
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            gameManager.Platform = SpawnPlayer();
            SpawnBlocks();
        }

        private GameObject SpawnPlayer() => _playerSpawner.SpawnPlayer();

        public void SpawnBlocks()
        {
            _blocks = _blocksSpawner.SpawnBlocks(_levelProvider.Level.BlocksPrefab);
        }


        public void Deinitialize()
        {
            Destroy(_blocks);
            _deinitializeEvent.Invoke();
        }
    }
}
