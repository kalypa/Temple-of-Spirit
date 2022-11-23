using UnityEngine;
using AdventurePuzzleKit;

namespace ThemedKeySystem
{
    public class ThemedKeyInventoryController : MonoBehaviour
    {
        [HideInInspector] public bool hasHeartKey;
        [HideInInspector] public bool hasDiamondKey;
        [HideInInspector] public bool hasSpadeKey;
        [HideInInspector] public bool hasClubKey;
        [HideInInspector] public bool hasRedKey;
        [HideInInspector] public bool hasBlueKey;
        [HideInInspector] public bool hasGrtar;
        [HideInInspector] public bool hasHalgr;
        [HideInInspector] public bool hasBattery;
        [HideInInspector] public bool hasSword;
        [HideInInspector] public bool hasSacredSword;
        [HideInInspector] public bool hasFlashLight;

        private bool isOpen;

        public static ThemedKeyInventoryController instance;
        public InventoryObj inventoryObject;
        public ItemDBObj databaseObject;
        ItemObj cloverKey;
        ItemObj spadeKey;
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
        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

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
                    hasHeartKey = true;
                    key = new Item(heartKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Diamond")
                {
                    hasDiamondKey = true;
                    key = new Item(diamondKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Club")
                {
                    hasClubKey = true;
                    key = new Item(cloverKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Spade")
                {
                    hasSpadeKey = true;
                    key = new Item(spadeKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if(keyName == "Red")
                {
                    hasRedKey = true;
                    key = new Item(redKey);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Blue")
                {
                    hasBlueKey = true;
                    key = new Item(blueKey);
                    inventoryObject.AddItem(key, 1);
                }


                else if (keyName == "Grtar")
                {
                    hasGrtar = true;
                    key = new Item(grtar);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Halgr")
                {
                    hasHalgr = true;
                    key = new Item(halgr);
                    inventoryObject.AddItem(key, 1);
                }

                else if(keyName == "Sword")
                {
                    hasSword = true;
                    key = new Item(sword);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "SacredSword")
                {
                    hasSacredSword = true;
                    key = new Item(sacredSword);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Battery")
                {
                    hasBattery = true;
                    key = new Item(battery);
                    inventoryObject.AddItem(key, 1);
                }

                else if (keyName == "Flashlight")
                {
                    hasFlashLight = true;
                    key = new Item(flashLight);
                    inventoryObject.AddItem(key, 1);
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
        }
    }
}
