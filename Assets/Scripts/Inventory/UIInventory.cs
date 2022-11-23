using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
[RequireComponent(typeof(EventTrigger))]
public abstract class UIInventory : MonoBehaviour
{ 
    public InventoryObj inventoryObj; 
     
    public Dictionary<GameObject, InvenSlot> uiSlotLists = new Dictionary<GameObject, InvenSlot>();
      
    private void Awake()
    { 
        createUISlots();
         
        for (int i = 0; i < inventoryObj.invenSlots.Length; i++)
        { 
            inventoryObj.invenSlots[i].inventoryObj = inventoryObj; 
            inventoryObj.invenSlots[i].OnPostUpload += OnEquipUpdate;
        }
    }
     
    protected virtual void Start()
    { 
        for (int i = 0; i < inventoryObj.invenSlots.Length; ++i)
        { 
            inventoryObj.invenSlots[i].uploadSlot(inventoryObj.invenSlots[i].item, inventoryObj.invenSlots[i].itemCnt);
        }
    }
     
    public abstract void createUISlots();
       
    public void OnEquipUpdate(InvenSlot inventSlot)
    {
        inventSlot.slotUI.transform.GetChild(0).GetComponent<Image>().sprite = inventSlot.item.item_id < 0 ? null : inventSlot.ItemObject.itemIcon;
        inventSlot.slotUI.transform.GetChild(0).GetComponent<Image>().color = inventSlot.item.item_id < 0 ? new Color(1, 1, 1, 0) : new Color(1, 1, 1, 1);
        inventSlot.slotUI.GetComponentInChildren<TextMeshProUGUI>().text = inventSlot.item.item_id < 0 ? string.Empty : (inventSlot.itemCnt == 1 ? string.Empty : inventSlot.itemCnt.ToString("n0"));
    }
} 