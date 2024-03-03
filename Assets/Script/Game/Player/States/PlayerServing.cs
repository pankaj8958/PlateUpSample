using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace PlayerFSM
{
    public class PlayerServing : State
    {
        PlayerController playerController;
        public PlayerServing(StateMachineBase _fsm, PlayerController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public PlayerServing(StateMachineBase _fsm) : base(_fsm)
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