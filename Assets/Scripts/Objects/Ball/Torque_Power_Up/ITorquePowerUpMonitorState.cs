namespace Objects.Ball.Torque_Power_Up
{
    public interface ITorquePowerUpMonitorState
    {
        void OnEnterState();

        void UpdateCharge(float deltaTime);

        void OnExitState();
    }
}
