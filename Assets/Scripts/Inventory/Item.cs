using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[Serializable]
public class Item
{ 
    public int item_id = -1; 
    public string item_name;
 
    public Item()
    {
        item_id = -1;
        item_name = "";
    }
     
     
    public Item(ItemObj itemObj)
    {
        item_name = itemObj.name;
        item_id = itemObj.itemData.item_id;
    }
} 