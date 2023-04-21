using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wepon Item", menuName ="Inventory/Items/New Wepon Item")]

public class WeponItem : ItemSriptebleObject
{
    public float damage;

    private void Start() {
        ItemType = ItemType.Weapon;
    } 
}
