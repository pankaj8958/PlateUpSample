using UnityEngine;
using NPC_FSM;
using System.Collections.Generic;

public class NPCController : MonoBehaviour
{
    [SerializeField] private List<Pack> completePacksList;
    [SerializeField] private NPC_StateMachine npcStateMachine;
    private Pack requirement;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentRequirement();
        npcStateMachine = new NPC_StateMachine();
        npcStateMachine.Add((int)NPCState.Idle, new NPCIdle(npcStateMachine, this));
        npcStateMachine.Add((int)NPCState.Waiting, new NPCWaiting(npcStateMachine, this));
        npcStateMachine.Add((int)NPCState.Eating, new NPCEating(npcStateMachine, this));
        npcStateMachine.Add((int)NPCState.Leave, new NPCLeave(npcStateMachine, this));
        npcStateMachine.SetCurrentState((int)NPCState.Idle);
    }
    private void SetCurrentRequirement()
    {
        if(completePacksList != null && completePacksList.Count > 0)
        {
            int randonNumber = Random.Range(0, completePacksList.Count);
            requirement = completePacksList[randonNumber];
        }
    }
    public bool ReceivedRequirement(Pack receivedItem)
    {
        return receivedItem.Id == requirement.Id;
    }
    // Update is called once per frame
    void Update()
    {
        npcStateMachine.Update();
    }
    public bool IsBuzy()
    {
        return  (npcStateMachine.CurrentState == (int)NPCState.Waiting
            || npcStateMachine.CurrentState == (int)NPCState.Eating);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
