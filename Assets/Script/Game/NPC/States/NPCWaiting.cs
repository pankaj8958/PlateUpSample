using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace NPC_FSM
{
    public class NPCWaiting : State
    {
        NPCController playerController;
        private int waitTime;
        private float startTime;
        public NPCWaiting(StateMachineBase _fsm, NPCController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public NPCWaiting(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            waitTime = Random.Range(5, 10);
            startTime = Time.realtimeSinceStartup;
            base.Enter();
        }
        public override void Update()
        {
            base.Update();
            if((Time.realtimeSinceStartup - startTime) >= waitTime)
            {
                fsm.SetCurrentState((int)NPCState.Leave);
            }
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
