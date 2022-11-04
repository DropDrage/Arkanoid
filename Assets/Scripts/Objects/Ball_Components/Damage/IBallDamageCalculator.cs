using JetBrains.Annotations;
using Objects.Ball_Components.Damage.Hit;
using Objects.Ball_Components.Damage.Torque;

namespace Objects.Ball_Components.Damage
{
    public interface IBallDamageCalculator : IDamageCalculator
    {
        void SetHitDamageCalculator([NotNull] IHitDamageCalculator newHitDamageCalculator);
        void ResetHitDamageCalculator();

        void SetTorqueDamageCalculator([NotNull] ITorqueDamageCalculator newTorqueDamageCalculator);
        void ResetTorqueDamageCalculator();
    }
}
