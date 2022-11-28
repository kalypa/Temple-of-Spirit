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
        private DG.Tweening.Sequence sequence;
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
                    PickupSound();
                    gameObject.SetActive(false);
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
            if (keyType != KeyTheme.SacredSword)
            {
                PickupSound();
                if (keyType != KeyTheme.Note)
                {
                    gameObject.SetActive(false);
                }
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
            ThemedKeyInventoryController.Instance.DeleteInventory("SacredSword");
            GameManager.Instance.controller.enabled = false;
            sequence = DOTween.Sequence();
            Vignette playerEyeDown = VolumeChange.Instance.vignette;
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
            enemySurprise = new Vector3(GameManager.Instance.player.transform.position.x + 0.5f, 11, GameManager.Instance.player.transform.position.z - 1f);
            GameManager.Instance.enemy.transform.position = enemySurprise;
            GameManager.Instance.enemy.SetActive(true);
            GameManager.Instance.enemy.transform.DOMoveY(10.1f, 1.5f);
        }

        private void Game()
        {
            sequence.Kill();
            GameManager.Instance.fadePanel.SetActive(true);
            VolumeChange.Instance.vignette.center.value = new Vector2(0.5f, 0.5f);
            VolumeChange.Instance.vignette.intensity.value = 0;
            GameManager.Instance.enemy.SetActive(false);
            GameManager.Instance.flashlight.SetActive(true);
            GameManager.Instance.note.SetActive(true);
            GameManager.Instance.fog.SetActive(false);
            VolumeChange.Instance.volume.weight = 1f;
            OnClickManager.Instance.invisibleWall.SetActive(false);
            OnClickManager.Instance.invisibleWall2.SetActive(true);
            OnClickManager.Instance.fadeImage.DOFade(0, 8);
            DOTween.Kill(GameManager.Instance.player);
            Invoke("KillDo", 8.5f);
            GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
            GameManager.Instance.player.transform.rotation = Quaternion.Euler(0, 180, 0);
            GameManager.Instance.controller.enabled = true;
            GameManager.Instance.ghost.SetActive(true);

        }

        private void KillDo()
        {
            DOTween.Kill(OnClickManager.Instance.fadeImage);
            GameManager.Instance.fadePanel.SetActive(false);
            OnClickManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
        }
    }
}
