using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType : int  
{
    CloverKey,
    SpadeKey,
    HeartKey,
    DiamondKey,
    ChestKey1,
    ChestKey2,
    Battery,
    Flashlight,
    SwordPiece1,
    SwordPiece2,
    SwordPiece3,
    SacredSword
}
 
[CreateAssetMenu(fileName ="New Item", menuName = "Inventory System/Items/New Item")]
public class ItemObj : ScriptableObject
{ 
    public ItemType itemType; 
    public bool getFlagStackable;
    
    public Sprite itemIcon; 
    public GameObject objModelPrefab;
     
    public Item itemData = new Item();
     
    [TextArea(15, 20)]
    public string itemSummery;
     
    public Item createItemObj()
    { 
        Item new_Item = new Item(this);
        return new_Item;
    } 
} 