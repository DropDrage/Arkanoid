using Objects.Ball;

namespace Objects.Bonus.Modifier
{
    public abstract class BaseBallModifier
    {
        public void Apply(BallModel ball)
        {
            Modify(ball);
        }

        protected abstract void Modify(BallModel ball);
    }
}
