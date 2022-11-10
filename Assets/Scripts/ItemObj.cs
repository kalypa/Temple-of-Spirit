using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemType : int  
{
    DoorKey1,
    DoorKey2,
    DoorKey3,
    DoorKey4,
    ChestKey1,
    ChestKey2,
    Battery,
    SwordPiece1,
    SwordPiece2,
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