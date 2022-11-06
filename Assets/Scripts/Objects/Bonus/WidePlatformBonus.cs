using Objects.Platform;
using UnityEngine;

namespace Objects.Bonus
{
    public class WidePlatformBonus : BasePlatformBonus
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private float colliderWidth = 2.333333f;


        protected override void ApplyBonus(GameObject platform)
        {
            platform.GetComponent<PlatformResizer>().Resize(sprite, colliderWidth);
        }
    }
}
