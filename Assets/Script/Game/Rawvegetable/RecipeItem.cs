using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeItem : MonoBehaviour
{
    [SerializeField] private List<Pack> existingPacks;
    [SerializeField] private SpriteRenderer icon;
    private List<Item> rawItemsCollected = new List<Item>();

    private Pack prepFood;
    private Pack GetCookedPack()
    {
        Pack mixItemPack = null;
        foreach(Pack eachPack in existingPacks)
        {
            if (eachPack.IsReceipeRight(rawItemsCollected))
            {
                mixItemPack = eachPack;
                break;
            }
        }
        return mixItemPack;
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
        if(prepFood != null)
        {
            player.CollectPack(prepFood);
            prepFood = null;
            icon.sprite = null;
        } else
        {
            rawItemsCollected.AddRange(player.GetCollectedRawItem());
            prepFood = GetCookedPack();
            if(prepFood != null)
            {
                icon.sprite = prepFood.iconImage;
            }
        }
    }
}
