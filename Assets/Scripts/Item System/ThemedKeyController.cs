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
        private Vignette playerEyeDown;
        public enum KeyTheme { None, Heart, Diamond, Club, Spade, Red, Blue, Grtar, Halgr, Sword, SacredSword, Battery, Flashlight, Note }
        public void KeyPickup()
        {
            switch (keyType)
            {
                case KeyTheme.Heart:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Heart");
                    break;
                case KeyTheme.Diamond:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Diamond");
                    break;
                case KeyTheme.Club:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Club");
                    break;
                case KeyTheme.Spade:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Spade");
                    break;
                case KeyTheme.Red:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Red");
                    break;
                case KeyTheme.Blue:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Blue");
                    break;
                case KeyTheme.Grtar:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Grtar");
                    break;
                case KeyTheme.Halgr:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Halgr");
                    break;
                case KeyTheme.Sword:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Sword");
                    break;
                case KeyTheme.SacredSword:
                    ThemedKeyInventoryController.Instance.UpdateInventory("SacredSword");
                    ThemedKeyInventoryController.Instance.DeleteInventory("SacredSword");
                    Invoke("GameStart", 0.5f);
                    break;
                case KeyTheme.Battery:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Battery");
                    break;
                case KeyTheme.Flashlight:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Flashlight");
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
            GameManager.Instance.controller.enabled = false;
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            playerEyeDown = VolumeChange.Instance.vignette;
            sequence.Append(DOTween.To(() => playerEyeDown.center.value, y => playerEyeDown.center.value = y, new Vector2(0.5f, -3f), 1f));
            sequence.Append(DOTween.To(() => playerEyeDown.center.value, y => playerEyeDown.center.value = y, new Vector2(0.5f, -1f), 1f));
            sequence.Append(DOTween.To(() => playerEyeDown.center.value, y => playerEyeDown.center.value = y, new Vector2(0.5f, -3f), 1f));
            sequence.Append(DOTween.To(() => playerEyeDown.center.value, y => playerEyeDown.center.value = y, new Vector2(0.5f, -1f), 1f));
            Invoke("PlayerFalling", 4f);
            sequence.Insert(4, DOTween.To(() => playerEyeDown.center.value, y => playerEyeDown.center.value = y, new Vector2(0.5f, -6.7f), 7f));
            Invoke("SurpriseEnemy", 4f);
            Invoke("Game", 9f);
        }

        private void PlayerFalling()
        {
            GameManager.Instance.player.transform.DORotateQuaternion(falling, 0.5f).SetEase(Ease.InQuad);
            GameManager.Instance.player.transform.DOMoveX(GameManager.Instance.player.transform.position.x + 0.5f, 1f);
        }

        private void SurpriseEnemy()    
        {
            enemySurprise = new Vector3(GameManager.Instance.player.transform.position.x + 0.3f, 11, GameManager.Instance.player.transform.position.z - 1f);
            GameManager.Instance.enemy.transform.position = enemySurprise;
            GameManager.Instance.enemy.SetActive(true);
            GameManager.Instance.enemy.transform.DOMoveY(10.1f, 1.5f);
        }

        private void Game()
        {
            GameManager.Instance.fadePanel.SetActive(true);
            playerEyeDown.center.value = new Vector2(0.5f, 0.5f);
            GameManager.Instance.fog.SetActive(false);
            VolumeChange.Instance.volume.weight = 0.99f;
            OnClickManager.Instance.invisibleWall.SetActive(false);
            OnClickManager.Instance.invisibleWall2.SetActive(true);
            OnClickManager.Instance.fadeImage.DOFade(0, 4);
            GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
            GameManager.Instance.controller.enabled = true;
            GameManager.Instance.ghost.SetActive(true);
            if (OnClickManager.Instance.fadeImage.color.a == 0)
            {
                GameManager.Instance.fadePanel.SetActive(false);
                OnClickManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
            }

        }
    }
}
