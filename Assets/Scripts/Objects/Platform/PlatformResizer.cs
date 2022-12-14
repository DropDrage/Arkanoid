using System;
using UnityEngine;

namespace Objects.Platform
{
    public class PlatformResizer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        [SerializeField] private CapsuleCollider2D collider;

        public float CurrentWidth => collider.size.x;

        public event Action<float> SizeChanged;


        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
            collider = GetComponent<CapsuleCollider2D>();
        }


        public void Resize(Sprite newSprite, float newWidth)
        {
            renderer.sprite = newSprite;
            collider.size = new Vector2(newWidth, collider.size.y);

            SizeChanged?.Invoke(newWidth);
        }
    }
}
