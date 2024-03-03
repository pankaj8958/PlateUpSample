using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    [SerializeField] private SpriteRenderer iconImage;
    
    private void Start()
    {
        iconImage.sprite = itemData.iconImage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.OnInteraction += OnClickAction;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.OnInteraction -= OnClickAction;
        }
    }
    private void OnClickAction(PlayerController player)
    {
        player.AddRawItem(itemData);
    }
}
