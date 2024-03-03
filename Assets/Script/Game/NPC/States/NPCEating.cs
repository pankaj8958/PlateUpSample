using UnityEngine;
using FSM;
namespace NPC_FSM
{
    public class NPCEating : State
    {
        NPCController playerController;
        private int eatTime;
        private float startTime;
        public NPCEating(StateMachineBase _fsm, NPCController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public NPCEating(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            eatTime = Random.Range(2000, 8000);
            startTime = Time.realtimeSinceStartup;
            base.Enter();
        }
        public override void Update()
        {
            if ((Time.realtimeSinceStartup - startTime) >= eatTime)
            {
                fsm.SetCurrentState((int)NPCState.Leave);
            }
            base.Update();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
