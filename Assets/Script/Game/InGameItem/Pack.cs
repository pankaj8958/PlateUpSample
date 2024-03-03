using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Config/Pack")]
public class Pack : Item
{
    public List<Item> items;

    public bool IsReceipeRight(List<Item> rawFood)
    {
        return Enumerable.SequenceEqual(items.OrderBy(t => t.Id), rawFood.OrderBy(t => t.Id));
    }
}
