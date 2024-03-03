using FSM;
namespace PlayerFSM
{
    public enum PlayerState
    {
        Idle,
        Move,
        DishWashing,
        Chopping,
        Collected,
        Serving
    }
    [System.Serializable]
    public class PlayerStateMachine : StateMachineBase
    {
    }
}
