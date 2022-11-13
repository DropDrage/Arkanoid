using JetBrains.Annotations;
using UnityEngine;

namespace Managers.Level
{
    [CreateAssetMenu(menuName = "Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField] private GameObject blocksPrefab;
        [CanBeNull, SerializeField] private Level nextLevel;

        public GameObject BlocksPrefab => blocksPrefab;
        [CanBeNull] public Level NextLevel => nextLevel;
    }
}
