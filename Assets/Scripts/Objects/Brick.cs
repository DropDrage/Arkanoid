using System;
using Managers;
using UnityEngine;
using VContainer;

namespace Objects
{
    [DisallowMultipleComponent]
    public class Brick : MonoBehaviour, IDamageable
    {
        [Min(0), SerializeField] private int health;
        private int Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    Destroy(gameObject);
                    _soundManager.PlayBrickDestroySound();
                }
            }
        }

        private SoundManager _soundManager;
        

        [Inject]
        private void Construct(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }
    

        public void DealDamage(int damage)
        {
#if UNITY_EDITOR
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative");
            }
#endif

            Health -= damage;
        }
    }
}
