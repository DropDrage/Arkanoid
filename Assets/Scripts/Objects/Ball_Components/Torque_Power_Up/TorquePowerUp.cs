using Managers;
using UnityEngine;
using VContainer;

namespace Objects.Ball_Components.Torque_Power_Up
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TorquePowerUp : MonoBehaviour
    {
        [Min(0f), SerializeField] private float angularVelocity;
        [SerializeField] private float angularVelocityAfterDeactivation;
        [Min(0f), SerializeField] private float damage;

        [SerializeField] private PhysicsMaterial2D physicsMaterial;

        private SoundManager _soundManager;
        private Rigidbody2D _rigidbody;

        private PhysicsMaterial2D _materialBeforePowerUp;

        public float Damage => damage;


        [Inject]
        private void Construct(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        private void OnEnable()
        {
            _soundManager.PlayPowerUpActivationSound();
            _materialBeforePowerUp = _rigidbody.sharedMaterial;
            _rigidbody.sharedMaterial = physicsMaterial;
            _rigidbody.angularVelocity = angularVelocity * Mathf.Sign(_rigidbody.angularVelocity);
        }

        private void OnDisable()
        {
            _rigidbody.sharedMaterial = _materialBeforePowerUp;
            _rigidbody.angularVelocity = 1000;
            _soundManager.PlayPowerUpDeactivationSound();
        }


        private void OnCollisionExit2D()
        {
            if (enabled)
            {
                _rigidbody.angularVelocity = angularVelocity * Mathf.Sign(_rigidbody.angularVelocity);
            }
        }
    }
}
