using UnityEngine;

namespace Objects.Ball
{
    public class BallModel : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private CircleCollider2D collider;
        [SerializeField] private SpriteRenderer renderer;


        private Transform _transform;

        public Vector3 Position => _transform.position;

        public Rigidbody2D Rigidbody => rigidbody;
        public CircleCollider2D Collider => collider;
        public SpriteRenderer Renderer => renderer;


        private void Awake()
        {
            _transform = transform;
        }
    }
}
