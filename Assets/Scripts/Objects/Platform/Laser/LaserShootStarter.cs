using System.Collections;
using UnityEngine;

namespace Objects.Platform.Laser
{
    public class LaserShootStarter : MonoBehaviour
    {
        [SerializeField] private float shootStartDelay;

        [SerializeField] private GameObject leftGun;
        [SerializeField] private GameObject rightGun;


        public void StartShoot()
        {
            leftGun.SetActive(true);
            StartCoroutine(ActivateRightLaserDelayed());
        }

        private IEnumerator ActivateRightLaserDelayed()
        {
            yield return new WaitForSeconds(shootStartDelay);
            rightGun.SetActive(true);
        }
    }
}
