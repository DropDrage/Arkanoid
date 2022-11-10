using Objects.Ball;
using UnityEngine;

namespace Objects.Bonus.Modifier
{
    public class BigBallModifier : BaseBallModifier
    {
        private float _colliderRadius;
        private float _mass;

        private Sprite _sprite;


        public BigBallModifier(float colliderRadius, float mass, Sprite sprite)
        {
            _colliderRadius = colliderRadius;
            _mass = mass;
            _sprite = sprite;
        }


        protected override void Modify(BallModel ball)
        {
            ball.Collider.radius = _colliderRadius;
            ball.Rigidbody.mass = _mass;
            ball.Renderer.sprite = _sprite;
        }
    }
}
