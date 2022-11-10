using Objects.Ball.Damage.Hit;
using Objects.Ball.Damage.Torque;
using UnityEngine;

namespace Objects.Ball.Damage
{
    [RequireComponent(typeof(BallModel))]
    public class BallDamageCalculator : MonoBehaviour, IBallDamageCalculator
    {
        [SerializeField] private MassDependentHitDamageCalculator defaultHitDamageCalculator;
        [SerializeField] private DefaultTorqueDamageCalculator defaultTorqueDamageCalculator;

        private Rigidbody2D _rigidbody;

        private IHitDamageCalculator _hitDamageCalculator;
        private ITorqueDamageCalculator _torqueDamageCalculator;

        public float Damage =>
            _hitDamageCalculator.CalculateDamage(_rigidbody)
            + _torqueDamageCalculator.CalculateTorqueDamage(_rigidbody);


        private void Awake()
        {
            _rigidbody = GetComponent<BallModel>().Rigidbody;
        }

        private void Start()
        {
            ResetHitDamageCalculator();
            ResetTorqueDamageCalculator();
        }


        public void SetHitDamageCalculator(IHitDamageCalculator newHitDamageCalculator)
        {
            _hitDamageCalculator = newHitDamageCalculator;
        }

        public void ResetHitDamageCalculator()
        {
            _hitDamageCalculator = defaultHitDamageCalculator;
        }


        public void SetTorqueDamageCalculator(ITorqueDamageCalculator newTorqueDamageCalculator)
        {
            _torqueDamageCalculator = newTorqueDamageCalculator;
        }

        public void ResetTorqueDamageCalculator()
        {
            _torqueDamageCalculator = defaultTorqueDamageCalculator;
        }
    }
}
