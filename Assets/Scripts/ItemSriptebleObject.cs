using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Default, Potion, Quest, Weapon}

public class ItemSriptebleObject : ScriptableObject
{
    public GameObject itemPrefab;
    public ItemType ItemType;
    public Sprite icon;
    public string itemName;
    public int MaxAmout;
    public string ItemDescription;
}
