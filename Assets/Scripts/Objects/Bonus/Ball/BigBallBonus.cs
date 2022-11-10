using Managers;
using Objects.Bonus.Modifier;
using UnityEngine;

namespace Objects.Bonus.Ball
{
    public class BigBallBonus : BaseBallBonus
    {
        [SerializeField] private float colliderRadius;
        [SerializeField] private float mass;

        [Space]
        [SerializeField] private Sprite sprite;


        protected override void ApplyBonus(BallsManager ballsManager)
        {
            var modifier = new BigBallModifier(colliderRadius, mass, sprite);
            ballsManager.AddModifier(modifier);
        }
    }
}
