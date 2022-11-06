using UnityEngine;

namespace Objects.Brick
{
    public class BonusDropper : MonoBehaviour
    {
        [SerializeField] private GameObject bonus;


        public void Drop()
        {
            Instantiate(bonus, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
