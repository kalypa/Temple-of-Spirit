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

        private bool isOpen;

        public static ThemedKeyInventoryController instance;
        public InventoryObj inventoryObject;
        public ItemDBObj databaseObject;
        ItemObj cloverKey;
        ItemObj spadeKey;
        ItemObj heartKey;
        ItemObj diamondKey;
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
            }
           
        }

        private void ItemInit()
        {
            cloverKey = databaseObject.itemObjs[0];
            spadeKey = databaseObject.itemObjs[1];
            heartKey = databaseObject.itemObjs[2];
            diamondKey = databaseObject.itemObjs[3];
        }
    }
}
