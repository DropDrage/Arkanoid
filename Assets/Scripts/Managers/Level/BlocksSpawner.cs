using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Managers.Level
{
    public class BlocksSpawner : MonoBehaviour
    {
        private IObjectResolver _diContainer;


        [Inject]
        private void Construct(IObjectResolver diContainer)
        {
            _diContainer = diContainer;
        }


        public GameObject SpawnBlocks(GameObject blocksPrefab)
        {
            return _diContainer.Instantiate(blocksPrefab);
        }
    }
}
