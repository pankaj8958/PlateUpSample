using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace NPC_FSM
{
    public class NPCIdle : State
    {
        NPCController playerController;
        public NPCIdle(StateMachineBase _fsm, NPCController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public NPCIdle(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            base.Enter();
        }
        public override void Update()
        {
            base.Update();
            fsm.SetCurrentState((int)NPCState.Waiting);
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
