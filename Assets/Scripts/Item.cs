using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite image;

    public virtual void Use()
    {

    }
}
