using ThemedKeySystem;
using UnityEngine;

namespace AdventurePuzzleKit
{
    public class AKItemController : MonoBehaviour
    {
        [Header("Primary System Type")]
        [SerializeField] private SystemType _systemType = SystemType.None;

        private ThemedKeyItemController _themedKeyItemController;

        private enum SystemType { None, ThemedKeySys, }
        private void Start()
        {
            switch (_systemType)
            {
                case SystemType.ThemedKeySys: _themedKeyItemController = GetComponent<ThemedKeyItemController>(); break;
            }
        }

        public void InteractionType()
        {
            switch (_systemType)
            {
                case SystemType.ThemedKeySys: _themedKeyItemController.ObjectInteract(); break;
            }
        }
    }
}
