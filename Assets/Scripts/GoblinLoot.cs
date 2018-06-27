using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loottable")]
public class GoblinLoot : ScriptableObject
{
    [SerializeField]
    private List<Item> items;

    public void Add(Item newItem)
    {
        bool iteminbackpack = false;
        foreach (var item in items)
        {
            if (item == newItem)
            {
                iteminbackpack = true;
                break;
            }
        }

        if (iteminbackpack == false)
            items.Add(newItem);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
