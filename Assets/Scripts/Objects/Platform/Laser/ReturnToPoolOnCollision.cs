using UnityEngine;

namespace Objects.Platform.Laser
{
    public class ReturnToPoolOnCollision : MonoBehaviour
    {
        private IReturnablePool<GameObject> _pool;


        public IReturnablePool<GameObject> Pool
        {
            set => _pool = value;
        }


        private void OnCollisionEnter2D()
        {
            _pool.Return(gameObject);
        }
    }
}
