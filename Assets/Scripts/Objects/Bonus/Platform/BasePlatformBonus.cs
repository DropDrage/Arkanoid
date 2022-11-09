using UnityEngine;

namespace Objects.Bonus.Platform
{
    public abstract class BasePlatformBonus : MonoBehaviour, IBonus
    {
        public void Use(GameObject platform)
        {
            ApplyBonus(platform);
            Destroy(gameObject);
        }

        protected abstract void ApplyBonus(GameObject platform);
    }
}
