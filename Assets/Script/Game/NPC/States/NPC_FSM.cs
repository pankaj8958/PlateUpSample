using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace NPC_FSM
{
    public enum NPCState
    {
        Idle,
        Waiting,
        Eating,
        Leave
    }
    [System.Serializable]
    public class NPC_StateMachine : StateMachineBase
    {
    }
}
