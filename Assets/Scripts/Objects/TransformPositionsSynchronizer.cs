using UnityEngine;
using Utils;

namespace Objects
{
    public class TransformPositionsSynchronizer : MonoBehaviour
    {
        [SerializeField] private Transform mainTransform;

        [Space]
        [SerializeField] private Transform connectedTransform;
        [SerializeField] private Vector2 offset;


        private void Update()
        {
            var newPosition = mainTransform.position;
            newPosition.x += offset.x;
            newPosition.y += offset.y;

            connectedTransform.position = newPosition;
        }


        public void Connect(Transform mainTransform, Transform connectedTransform)
        {
            this.mainTransform = mainTransform;
            this.connectedTransform = connectedTransform;

            enabled = true;
        }

        public void Release()
        {
            enabled = false;
        }


        private void OnDrawGizmosSelected()
        {
            if (mainTransform != null)
            {
                var position = mainTransform.position;
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(position, 0.2f);

                var connectedPosition = position.Add(offset);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(position, connectedPosition);
                Gizmos.DrawWireSphere(connectedPosition, 0.2f);
            }
        }
    }
}
