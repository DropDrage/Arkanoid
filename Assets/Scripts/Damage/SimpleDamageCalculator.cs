using UnityEngine;

namespace Damage
{
    public class SimpleDamageCalculator : MonoBehaviour, IDamageCalculator
    {
        [Min(0f), SerializeField] private float damage;

        public float Damage => damage;
    }
}
