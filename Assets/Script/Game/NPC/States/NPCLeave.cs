using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace NPC_FSM
{
    public class NPCLeave : State
    {
        NPCController playerController;
        public NPCLeave(StateMachineBase _fsm, NPCController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public NPCLeave(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            base.Enter();
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
