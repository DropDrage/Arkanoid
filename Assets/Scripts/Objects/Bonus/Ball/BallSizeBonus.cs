using Managers;
using Objects.Bonus.Ball.Modifier;
using UnityEngine;

namespace Objects.Bonus.Ball
{
    public class BallSizeBonus : BaseBallBonus
    {
        [SerializeField] private float colliderRadius;
        [SerializeField] private float mass;

        [Space]
        [SerializeField] private Sprite sprite;


        protected override void ApplyBonus(BallsManager ballsManager)
        {
            var modifier = new BallSizeModifier(colliderRadius, mass, sprite);
            ballsManager.AddModifier(modifier);
        }
    }
}
