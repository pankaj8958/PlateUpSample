using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    public enum SpawnState
    {
        None,
        Start,
        Spawn,
        Waiting,
        Cooldown
    }
    [SerializeField] private GameObject npcPrefab;
    [SerializeField] private RangeInt cooldownRange;

    private NPCController npcController;
    private SpawnState currentState;

    private void Start()
    {
        SetState(SpawnState.Start);
    }

    private async void SetState(SpawnState state)
    {
        if(currentState == state)
        {
            return;
        }
        currentState = state;
        switch (currentState)
        {
            case SpawnState.Start:
                OnStart();
                break;
            case SpawnState.Spawn:
                OnSpawn();
                break;
            case SpawnState.Waiting:
                OnWaiting();
                break;
            case SpawnState.Cooldown:
                OnCoolDown();
                break;
        }
    }
    private async void OnStart()
    {
        await Task.Yield();
        SetState(SpawnState.Spawn);
    }
    private async void OnSpawn()
    {
        if (npcController == null)
        {
            GameObject refObject = Instantiate(npcPrefab, this.transform);
            npcController = refObject.GetComponent<NPCController>();
        }
        await Task.Delay(1000);
        SetState(SpawnState.Waiting);
    }
    private async void OnWaiting()
    {
        while(npcController != null && npcController.IsBuzy())
        {
            await Task.Yield();
            //Waiting till current finishes
        }
        if(npcController)
            SetState(SpawnState.Cooldown);
    }
    private async void OnCoolDown()
    {
        Destroy(npcController.gameObject);
        int delay = Random.Range(100, 1000);
        await Task.Delay(delay);
        SetState(SpawnState.Start);
    }
}
