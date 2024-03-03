using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace PlayerFSM
{
    public class PlayerMove : State
    {
        PlayerController playerController;
        public float moveSpeed = 5;
        public PlayerMove(StateMachineBase _fsm, PlayerController controller) : base(_fsm)
        {
            playerController = controller;
        }
        public PlayerMove(StateMachineBase _fsm) : base(_fsm)
        {
        }
        public override void Enter()
        {
            base.Enter();
        }
        public override void Update()
        {   
            if (Input.GetKey(playerController.inputController.Config.rightKey))
            {
                playerController.transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            }
            else if (Input.GetKey(playerController.inputController.Config.leftKey))
            {
                playerController.transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

            }

            else if (Input.GetKey(playerController.inputController.Config.upKey))
            {
                playerController.transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            }
            else if (Input.GetKey(playerController.inputController.Config.downKey))
            {
                playerController.transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

            }
            base.Update();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }
}
