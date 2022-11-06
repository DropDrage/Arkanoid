using UnityEngine;
using Utils;

namespace Objects
{
    public class TransformPositionsSynchronizer : MonoBehaviour
    {
        [SerializeField] private Vector2 offset;

        [SerializeField] private Transform transform;
        [SerializeField] private Transform connectedTransform;


        private void Update()
        {
            var newPosition = transform.position;
            newPosition.x += offset.x;
            newPosition.y += offset.y;

            connectedTransform.position = newPosition;
        }


        public void Release()
        {
            enabled = false;
            Destroy(this);
        }


        private void OnDrawGizmosSelected()
        {
            var position = transform.position;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(position, 0.2f);

            var connectedPosition = position.Add(offset);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(position, connectedPosition);
            Gizmos.DrawWireSphere(connectedPosition, 0.2f);
        }
    }
}
