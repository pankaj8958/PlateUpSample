using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace PlayerFSM
{
    public class PlayerIdle : State
    {
        PlayerController playerController;
        public PlayerIdle(StateMachineBase _fsm, PlayerController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public PlayerIdle(StateMachineBase _fsm) : base(_fsm)
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
