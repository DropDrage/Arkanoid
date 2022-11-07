using System;
using Managers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using VContainer;

namespace Objects.Brick
{
    [DisallowMultipleComponent]
    public class DamageReceiver : MonoBehaviour, IDamageable
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
                    _oneShotSoundsPlayer.PlayBrickDestroySound();
                }
            }
        }

        [SerializeField] private UnityEvent destroy;


        private OneShotSoundsPlayer _oneShotSoundsPlayer;


        [Inject]
        private void Construct(OneShotSoundsPlayer oneShotSoundsPlayer)
        {
            _oneShotSoundsPlayer = oneShotSoundsPlayer;
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


        [Button]
        private void Kill()
        {
            DealDamage(health);
        }
    }
}
