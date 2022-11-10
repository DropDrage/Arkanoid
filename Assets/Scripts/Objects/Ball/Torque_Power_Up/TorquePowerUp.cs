using JetBrains.Annotations;
using Managers;
using UnityEngine;
using VContainer;

namespace Objects.Ball.Torque_Power_Up
{
    [RequireComponent(typeof(BallModel))]
    public class TorquePowerUp : MonoBehaviour
    {
        [Min(0f), SerializeField] private float angularVelocity;
        [SerializeField] private float angularVelocityAfterDeactivation;

        [field: Space]
        [field: Min(0f)]
        [field: SerializeField]
        public float Damage { get; [UsedImplicitly] private set; }

        [SerializeField] private PhysicsMaterial2D physicsMaterial;

        private OneShotSoundsPlayer _oneShotSoundsPlayer;
        private Rigidbody2D _rigidbody;

        private PhysicsMaterial2D _materialBeforePowerUp;


        [Inject]
        private void Construct(OneShotSoundsPlayer oneShotSoundsPlayer)
        {
            _oneShotSoundsPlayer = oneShotSoundsPlayer;
        }


        private void Awake()
        {
            _rigidbody = GetComponent<BallModel>().Rigidbody;
        }


        private void OnEnable()
        {
            _oneShotSoundsPlayer.PlayPowerUpActivationSound();
            _materialBeforePowerUp = _rigidbody.sharedMaterial;
            _rigidbody.sharedMaterial = physicsMaterial;
            _rigidbody.angularVelocity = angularVelocity * Mathf.Sign(_rigidbody.angularVelocity);
        }

        private void OnDisable()
        {
            _rigidbody.sharedMaterial = _materialBeforePowerUp;
            _rigidbody.angularVelocity = angularVelocityAfterDeactivation;
            _oneShotSoundsPlayer.PlayPowerUpDeactivationSound();
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
