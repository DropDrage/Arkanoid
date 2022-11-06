using Objects.Bonus;
using UnityEngine;

namespace Objects.Platform
{
    public class BonusUser : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<BasePlatformBonus>(out var platformBonus))
            {
                platformBonus.Use(gameObject);
            }
        }
    }
}
