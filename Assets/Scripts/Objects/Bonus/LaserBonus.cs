using Objects.Platform.Laser;
using UnityEngine;

namespace Objects.Bonus
{
    public class LaserBonus : BasePlatformBonus
    {
        [SerializeField] private GameObject lasersPrefab;


        protected override void ApplyBonus(GameObject platform)
        {
            var lasersObject = Instantiate(lasersPrefab, platform.transform);
            lasersObject.GetComponent<LasersOnEdgePlacer>().InitWithPlatform(platform);
        }
    }
}
