using Managers;
using UnityEngine;

namespace Objects.Bonus.Ball
{
    public class MoreBallsBonus : BaseBallBonus
    {
        [Min(1), SerializeField] private int additionalBallsCount;


        protected override void ApplyBonus(BallsManager ballsManager)
        {
            ballsManager.AddBallsFromBall(additionalBallsCount);
        }
    }
}
