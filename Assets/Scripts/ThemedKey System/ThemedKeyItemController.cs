using UnityEngine;

namespace ThemedKeySystem
{
    public class ThemedKeyItemController : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType = ItemType.None;

        private ThemedKeyController keyController;
        private ThemedKeyDoorController doorController;
        private ChestController chestController;
        private FlashlightController flashlightController;
        private BatteryController batteryController;
        private enum ItemType { None, Door, Key, Battery, Chest, FlashLight }

        private void Awake()
        {
            switch (_itemType)
            {
                case ItemType.Door:      
                    doorController = GetComponent<ThemedKeyDoorController>();
                    break;
                case ItemType.Chest:
                    chestController = GetComponent<ChestController>();
                    break;
                case ItemType.Key:
                    keyController = GetComponent<ThemedKeyController>();
                    break;
                case ItemType.Battery:
                    batteryController = GetComponent<BatteryController>();
                    break;
                case ItemType.FlashLight:
                    flashlightController = GetComponent<FlashlightController>();
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
                case ItemType.Chest:
                    chestController.CheckChest();
                    break;
                case ItemType.Key:
                    keyController.KeyPickup();
                    break;
                case ItemType.Battery:
                    break;
                case ItemType.FlashLight:
                    break;
            }
        }
    }
}
