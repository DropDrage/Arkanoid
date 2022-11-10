using UnityEngine;

namespace Objects.Bonus
{
    public abstract class BaseBonus<T> : MonoBehaviour
    {
        public void Use(T target)
        {
            ApplyBonus(target);
            Destroy(gameObject);
        }

        protected abstract void ApplyBonus(T target);
    }
}
