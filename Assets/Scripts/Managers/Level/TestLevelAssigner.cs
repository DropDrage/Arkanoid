using UnityEngine;
using VContainer;

namespace Managers.Level
{
    public class TestLevelAssigner : MonoBehaviour
    {
        [SerializeField] private Level testLevel;

        private LevelProvider _levelProvider;


        [Inject]
        private void Construct(LevelProvider levelProvider)
        {
            _levelProvider = levelProvider;
        }


        private void Awake()
        {
#if UNITY_EDITOR
            _levelProvider.Level = testLevel;
#endif
            Destroy(gameObject);
        }
    }
}
