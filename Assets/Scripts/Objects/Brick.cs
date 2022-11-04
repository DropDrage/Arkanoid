using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

namespace Objects
{
    [DisallowMultipleComponent]
    public class Brick : MonoBehaviour, IDamageable
    {
        [Min(0), SerializeField] private float health;
        private float Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    destroy.Invoke();
                    Destroy(gameObject);
                    _soundManager.PlayBrickDestroySound();
                }
            }
        }

        [SerializeField] private UnityEvent destroy;


        private SoundManager _soundManager;


        [Inject]
        private void Construct(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }


        public void DealDamage(float damage)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative");
            }
#endif

            Health -= damage;
        }
    }
}
