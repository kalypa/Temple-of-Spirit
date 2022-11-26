using UnityEngine;
using ItemSystem;
using Unity.VisualScripting;
using InputSystem;
using DG.Tweening;
using UnityEngine.Rendering.HighDefinition;

namespace ItemInven
{
    public class ThemedKeyController : MonoBehaviour
    {
        [Header("Type of Key")]
        [SerializeField] private KeyTheme keyType = KeyTheme.None;

        [SerializeField] private string keySound = "ThemedKeyPickup";
        [SerializeField] private string otherSound = "OtherPickUp";
        [SerializeField] private string noteSound = "NoteOpen";
        private Quaternion falling = Quaternion.Euler(0, 180, 106.6f);
        private Vector3 enemySurprise;
        private Vector2 eyeClosing;
        public enum KeyTheme { None, Heart, Diamond, Club, Spade, Red, Blue, Grtar, Halgr, Sword, SacredSword, Battery, Flashlight, Note }
        public void KeyPickup()
        {
            switch (keyType)
            {
                case KeyTheme.Heart:
                    ThemedKeyInventoryController.instance.UpdateInventory("Heart");
                    break;
                case KeyTheme.Diamond:
                    ThemedKeyInventoryController.instance.UpdateInventory("Diamond");
                    break;
                case KeyTheme.Club:
                    ThemedKeyInventoryController.instance.UpdateInventory("Club");
                    break;
                case KeyTheme.Spade:
                    ThemedKeyInventoryController.instance.UpdateInventory("Spade");
                    break;
                case KeyTheme.Red:
                    ThemedKeyInventoryController.instance.UpdateInventory("Red");
                    break;
                case KeyTheme.Blue:
                    ThemedKeyInventoryController.instance.UpdateInventory("Blue");
                    break;
                case KeyTheme.Grtar:
                    ThemedKeyInventoryController.instance.UpdateInventory("Grtar");
                    break;
                case KeyTheme.Halgr:
                    ThemedKeyInventoryController.instance.UpdateInventory("Halgr");
                    break;
                case KeyTheme.Sword:
                    ThemedKeyInventoryController.instance.UpdateInventory("Sword");
                    break;
                case KeyTheme.SacredSword:
                    ThemedKeyInventoryController.instance.UpdateInventory("SacredSword");
                    GameStart();
                    break;
                case KeyTheme.Battery:
                    ThemedKeyInventoryController.instance.UpdateInventory("Battery");
                    break;
                case KeyTheme.Flashlight:
                    ThemedKeyInventoryController.instance.UpdateInventory("Flashlight");
                    break;
                case KeyTheme.Note:
                    NoteController.Instance.ExpensionNote();
                    break;
            }
            PickupSound();
            if(keyType != KeyTheme.Note)
            {
                gameObject.SetActive(false);
            }
        }

        void PickupSound()
        {
            switch (keyType)
            {
                case KeyTheme.Heart:
                case KeyTheme.Diamond:
                case KeyTheme.Club:
                case KeyTheme.Spade:
                case KeyTheme.Red:
                case KeyTheme.Blue:
                    AudioManager.instance.Play(keySound);
                    break;
                case KeyTheme.Grtar:
                case KeyTheme.Halgr:
                case KeyTheme.Sword:
                case KeyTheme.SacredSword:
                case KeyTheme.Battery:
                case KeyTheme.Flashlight:
                    AudioManager.instance.Play(otherSound);
                    break;
                case KeyTheme.Note:
                    AudioManager.instance.Play(noteSound);
                    break;
            }
        }

        public void GameStart()
        {
            Vignette playerEyeDown = GameManager.Instance.volumeObject.GetComponent<Vignette>();
            eyeClosing = playerEyeDown.center.value;
            DOTween.To(() => eyeClosing, y => eyeClosing = y, new Vector2(0.5f, 6.7f), 4f);
            GameManager.Instance.controller.enabled = false;
            GameManager.Instance.player.transform.DORotateQuaternion(falling, 0.5f);
            GameManager.Instance.player.transform.DOMoveX(GameManager.Instance.player.transform.position.x + 0.5f, 1f);
            enemySurprise = new Vector3(GameManager.Instance.player.transform.position.x + 0.693f, 11, GameManager.Instance.player.transform.position.z - 1f);
            GameManager.Instance.enemy.transform.position = enemySurprise;
            GameManager.Instance.enemy.SetActive(true);
            GameManager.Instance.enemy.transform.DOMoveY(10.1f, 1f);
        }
    }
}
