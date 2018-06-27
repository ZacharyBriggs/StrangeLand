using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class InventoryScriptable : ScriptableObject
{
    public List<WeaponScriptable> Weapons;
}
