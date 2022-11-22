using UnityEngine;

namespace ThemedKeySystem
{
    public class ThemedKeyItemController : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType = ItemType.None;

        private ThemedKeyController keyController;
        private ThemedKeyDoorController doorController;
        private enum ItemType { None, Door, Key, Battery, ChestKey }

        private void Awake()
        {
            switch (_itemType)
            {
                case ItemType.Door:      
                    doorController = GetComponent<ThemedKeyDoorController>();
                    break;
                case ItemType.Key:
                    keyController = GetComponent<ThemedKeyController>();
                    break;
                case ItemType.Battery:
                    break;
                case ItemType.ChestKey:
                    break;
            }
        }

        public void ObjectInteract()
        {
            switch (_itemType)
            {
                case ItemType.Door:
                    doorController.CheckDoor();
                    break;
                case ItemType.Key:
                    keyController.KeyPickup();
                    break;
                case ItemType.Battery:
                    break;
            }
        }
    }
}
