using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerFSM;
using System;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int pIndex;
    [SerializeField] private PlayerStateMachine playerStateMachine;
    [SerializeField] private TextMesh alertText;
    public static Action<PlayerController> OnInteraction;
    public InputController inputController;
    public int PlayerIndex => pIndex;

    private const int maxItemsCarry = 2;

    [SerializeField] private Dictionary<int, Item> rawCollection = new Dictionary<int, Item>();
    [SerializeField] private Pack dishCooked;
    private bool isInteractable;
    // Start is called before the first frame update
    void Start()
    {
        playerStateMachine = new PlayerStateMachine();
        playerStateMachine.Add((int)PlayerState.Idle, new PlayerIdle(playerStateMachine, this));
        playerStateMachine.Add((int)PlayerState.Move, new PlayerMove(playerStateMachine, this));
        playerStateMachine.Add((int)PlayerState.Chopping, new PlayerChopping(playerStateMachine, this));
        playerStateMachine.Add((int)PlayerState.Collected, new PlayerCollected(playerStateMachine, this));
        playerStateMachine.Add((int)PlayerState.Serving, new PlayerServing(playerStateMachine, this));
        playerStateMachine.SetCurrentState((int)PlayerState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputController.IsMoving())
        {
            playerStateMachine.SetCurrentState((int)PlayerState.Move);
        } else if(inputController.IsInteracting() && isInteractable)
        {
            playerStateMachine.SetCurrentState((int)PlayerState.Collected);
        } else
        {
            playerStateMachine.SetCurrentState((int)PlayerState.Idle);
        }
        playerStateMachine.Update();
    }

    public void AddRawItem(Item item)
    {
        if(rawCollection.Count >= maxItemsCarry)
        {
            //Max item added
            return;
        }
        if(!rawCollection.ContainsKey(item.Id))
        {
            rawCollection.Add(item.Id, item);
        }
    }
    public void CollectPack(Pack item)
    {
        dishCooked = item;
    }
    public List<Item> GetCollectedRawItem()
    {
        List<Item> collectedItem = rawCollection.Values.ToList();
        rawCollection.Clear();
        return collectedItem;
    }
    public void SetText(string message)
    {
        alertText.text = message;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            isInteractable = true;
            SetText($"Press {inputController.GetInteractiveKey()}");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            isInteractable = false;
            SetText("");
        }
    }
}
