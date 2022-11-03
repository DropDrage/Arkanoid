namespace Objects.Ball_Components.Torque_Power_Up
{
    public interface ITorquePowerUpMonitorState
    {
        void OnEnterState();

        void UpdateCharge();

        void OnExitState();
    }
}
