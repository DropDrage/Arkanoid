using Managers;
using UnityEngine;

namespace Objects.Bonus.Ball
{
    public abstract class BaseBallBonus : MonoBehaviour, IBonus
    {
        public void Use(BallsManager ballsManager)
        {
            ApplyBonus(ballsManager);
            Destroy(gameObject);
        }

        protected abstract void ApplyBonus(BallsManager ballsManager);
    }
}
