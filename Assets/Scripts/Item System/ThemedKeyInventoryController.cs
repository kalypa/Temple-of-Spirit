using UnityEngine;
using ItemSystem;

namespace ItemInven
{
    public class ThemedKeyInventoryController : SingleMonobehaviour<ThemedKeyInventoryController>
    {

        [SerializeField] private GameObject endingGrtar;
        [SerializeField] private GameObject endingHalgr;
        [SerializeField] private GameObject endingSword;

        private bool isOpen;

        public InventoryObj inventoryObject;
        public ItemDBObj databaseObject;
        ItemObj cloverKey;
        ItemObj spadeKey;
        ItemObj firstKey;
        ItemObj heartKey;
        ItemObj diamondKey;
        ItemObj redKey;
        ItemObj blueKey;
        ItemObj grtar;
        ItemObj halgr;
        ItemObj sword;
        ItemObj sacredSword;
        ItemObj battery;
        ItemObj flashLight;

        private void Start()
        {
            inventoryObject.Clear();
            ItemInit();
        }

        public void UpdateInventory(string keyName)
        {
            Item key;
            if (databaseObject.itemObjs.Length > 0)
            {
                if (keyName == "Heart")
                {
                    GameManager.Instance.hasHeartKey = true;
                    key = new Item(heartKey);
                    inventoryObject.AddItem(key, 1);

                }

                else if (keyName == "Diamond")
                {
                    GameManager.Instance.hasDiamondKey = true;
                    key = new Item(diamondKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Club")
                {
                    GameManager.Instance.hasClubKey = true;
                    key = new Item(cloverKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Spade")
                {
                    GameManager.Instance.hasSpadeKey = true;
                    key = new Item(spadeKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "First")
                {
                    GameManager.Instance.hasFirstKey = true;
                    key = new Item(firstKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if(keyName == "Red")
                {
                    GameManager.Instance.hasRedKey = true;
                    key = new Item(redKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Blue")
                {
                    GameManager.Instance.hasBlueKey = true;
                    key = new Item(blueKey);
                    inventoryObject.AddItem(key, 1);
                }


                else if (keyName == "Grtar")
                {
                    GameManager.Instance.hasGrtar = true;
                    key = new Item(grtar);
                    endingGrtar.tag = "Put";
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Halgr")
                {
                    GameManager.Instance.hasHalgr = true;
                    key = new Item(halgr);
                    endingHalgr.tag = "Put";
                    inventoryObject.AddItem(key, 1);
                }

                else if(keyName == "Sword")
                {
                    GameManager.Instance.hasSword = true;
                    key = new Item(sword);
                    endingSword.tag = "Put";
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "SacredSword")
                {
                    GameManager.Instance.hasSacredSword = true;
                    key = new Item(sacredSword);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Battery")
                {
                    GameManager.Instance.hasBattery = true;
                    key = new Item(battery);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Flashlight")
                {
                    GameManager.Instance.hasFlashLight = true;
                    key = new Item(flashLight);
                    inventoryObject.AddItem(key, 1);
                }

            }

        }

        public void DeleteInventory(string keyName)
        {
            Item key;
            if (databaseObject.itemObjs.Length > 0)
            {
                if (keyName == "Heart")
                {
                    GameManager.Instance.hasHeartKey = false;
                    key = new Item(heartKey);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "Diamond")
                {
                    GameManager.Instance.hasDiamondKey = false;
                    key = new Item(diamondKey);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "Club")
                {
                    GameManager.Instance.hasClubKey = false;
                    key = new Item(cloverKey);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "Spade")
                {
                    GameManager.Instance.hasSpadeKey = false;
                    key = new Item(spadeKey);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "First")
                {
                    GameManager.Instance.hasFirstKey = false;
                    key = new Item(firstKey);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "Red")
                {
                    GameManager.Instance.hasRedKey = true;
                    key = new Item(redKey);
                    inventoryObject?.seachItemInInven(key)?.destoryItem();
                }

                else if (keyName == "Blue")
                {
                    GameManager.Instance.hasBlueKey = false;
                    key = new Item(blueKey);
                    inventoryObject?.seachItemInInven(key)?.destoryItem();
                }


                else if (keyName == "Grtar")
                {
                    GameManager.Instance.hasGrtar = false;
                    key = new Item(grtar);
                    inventoryObject?.seachItemInInven(key)?.destoryItem();
                }

                else if (keyName == "Halgr")
                {
                    GameManager.Instance.hasHalgr = false;
                    key = new Item(halgr);
                    inventoryObject?.seachItemInInven(key)?.destoryItem();
                }

                else if (keyName == "Sword")
                {
                    GameManager.Instance.hasSword = false;
                    key = new Item(sword);
                    inventoryObject?.seachItemInInven(key)?.destoryItem();
                }

                else if (keyName == "SacredSword")
                {
                    GameManager.Instance.hasSacredSword = false;
                    key = new Item(sacredSword);
                    inventoryObject?.seachItemInInven(key).destoryItem();
                }

                else if (keyName == "Battery")
                {
                    key = new Item(battery);
                    if (inventoryObject?.seachItemInInven(key).itemCnt == 1)
                    {
                        GameManager.Instance.hasBattery = false;
                    }
                    inventoryObject?.seachItemInInven(key).minusCnt(1);
                }

            }

        }
        private void ItemInit()
        {
            cloverKey = databaseObject.itemObjs[0];
            spadeKey = databaseObject.itemObjs[1];
            heartKey = databaseObject.itemObjs[2];
            diamondKey = databaseObject.itemObjs[3];
            redKey = databaseObject.itemObjs[4];
            blueKey = databaseObject.itemObjs[5];
            grtar = databaseObject.itemObjs[6];
            halgr = databaseObject.itemObjs[7];
            sword = databaseObject.itemObjs[8];
            sacredSword = databaseObject.itemObjs[9];
            battery = databaseObject.itemObjs[10];
            flashLight = databaseObject.itemObjs[11];
            firstKey = databaseObject.itemObjs[12];
        }
    }
}
