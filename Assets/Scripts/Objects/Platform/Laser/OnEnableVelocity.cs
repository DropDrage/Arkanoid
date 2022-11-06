using UnityEngine;

namespace Objects.Platform.Laser
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class OnEnableVelocity : MonoBehaviour
    {
        [SerializeField] private Vector2 velocity;

        private Rigidbody2D _rigidbody;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rigidbody.velocity = velocity;
        }
    }
}
