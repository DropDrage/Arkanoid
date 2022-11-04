using UnityEngine;

namespace Objects
{
    public class BonusDropper : MonoBehaviour
    {
        [SerializeField] private GameObject drop;


        public void Drop()
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
