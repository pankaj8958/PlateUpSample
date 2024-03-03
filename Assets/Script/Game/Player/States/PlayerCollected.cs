using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace PlayerFSM
{
    public class PlayerCollected : State
    {
        PlayerController playerController;
        public PlayerCollected(StateMachineBase _fsm, PlayerController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public PlayerCollected(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            PlayerController.OnInteraction?.Invoke(playerController);
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