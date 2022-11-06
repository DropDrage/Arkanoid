using Damage;
using JetBrains.Annotations;
using Objects.Ball.Damage.Hit;
using Objects.Ball.Damage.Torque;

namespace Objects.Ball.Damage
{
    public interface IBallDamageCalculator : IDamageCalculator
    {
        void SetHitDamageCalculator([NotNull] IHitDamageCalculator newHitDamageCalculator);
        void ResetHitDamageCalculator();

        void SetTorqueDamageCalculator([NotNull] ITorqueDamageCalculator newTorqueDamageCalculator);
        void ResetTorqueDamageCalculator();
    }
}
