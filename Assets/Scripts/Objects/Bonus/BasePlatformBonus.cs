using UnityEngine;

namespace Objects.Bonus
{
    public abstract class BasePlatformBonus : MonoBehaviour
    {
        public void Use(GameObject platform)
        {
            ApplyBonus(platform);
            Destroy(gameObject);
        }

        protected abstract void ApplyBonus(GameObject platform);
    }
}
