using UnityEngine;
using ItemSystem;
namespace ItemInven
{
    public class ThemedKeyItemController : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType = ItemType.None;

        private ThemedKeyController keyController;
        private ThemedKeyDoorController doorController;
        private ChestController chestController;
        private SafeController safeController;
        private ClosetController closetController;
        private EndingItemController endingItemController;
        private enum ItemType { None, Door, Key, Chest, Safe, Closet, Ending }

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
                case ItemType.Safe:
                    safeController = GetComponent<SafeController>();
                    break;
                case ItemType.Closet:
                    closetController = GetComponent<ClosetController>();
                    break;
                case ItemType.Ending:
                    endingItemController = GetComponent<EndingItemController>();
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
                case ItemType.Safe:
                    safeController.ShowSafeLock();
                    break;
                case ItemType.Closet:
                    closetController.Hiding();
                    break;
                case ItemType.Ending:
                    endingItemController.PieceReturn();
                    break;
            }
        }
    }
}
