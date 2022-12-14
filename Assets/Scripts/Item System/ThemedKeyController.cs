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
        [SerializeField] private NoteController noteController;
        [SerializeField] private KeyTheme keyType = KeyTheme.None;

        [SerializeField] private string keySound = "ThemedKeyPickup";
        [SerializeField] private string otherSound = "OtherPickUp";
        [SerializeField] private string noteSound = "NoteOpen";
        [SerializeField] private string coughSound = "Cough";
        private DrawerController[] controller;
        private ChestController[] chestController;
        private ThemedKeyDoorController[] doorController;
        private SafeController safeController;
        private Quaternion falling = Quaternion.Euler(0, 180, 106.6f);
        private Vector3 enemySurprise;
        private DG.Tweening.Sequence sequence;
        public enum KeyTheme { None, Heart, Diamond, Club, Spade, Red, Blue, Grtar, Halgr, Sword, SacredSword, Battery, Flashlight, Note, First }
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
                    GameStart();
                    break;
                case KeyTheme.First:
                    ThemedKeyInventoryController.Instance.UpdateInventory("First");
                    break;
                case KeyTheme.Battery:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Battery");
                    break;
                case KeyTheme.Flashlight:
                    ThemedKeyInventoryController.Instance.UpdateInventory("Flashlight");
                    break;
                case KeyTheme.Note:
                    noteController.ExpensionNote();
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
                case KeyTheme.First:
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
            GameManager.Instance.walk.enabled = false;
            AudioManager.instance.Play(coughSound);
            GameManager.Instance.backgroundmusic.clip = GameManager.Instance.mainMusic;
            GameManager.Instance.backgroundmusic.Play();
            ThemedKeyInventoryController.Instance.DeleteInventory("SacredSword");
            GameManager.Instance.controller.enabled = false;
            GameManager.Instance.playerInput.enabled = false;
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
            enemySurprise = new Vector3(GameManager.Instance.player.transform.position.x + 1f, 11f, GameManager.Instance.player.transform.position.z -0.6f);
            GameManager.Instance.enemy.transform.position = enemySurprise;
            GameManager.Instance.enemy.transform.rotation = Quaternion.Euler(0, GameManager.Instance.player.transform.eulerAngles.y - 125, -180);
            GameManager.Instance.enemy.SetActive(true);
            AudioManager.instance.Play("Rising");
            GameManager.Instance.enemy.transform.DOMoveY(10.1f, 1.5f);
        }

        private void Game()
        {
            sequence.Kill();
            GameManager.Instance.fadePanel.SetActive(true);
            GameManager.Instance.dayText.text = "Day " + GameManager.Instance.playerDeathStack.ToString();
            GameManager.Instance.dayText.gameObject.SetActive(true);
            GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
            GameManager.Instance.player.transform.rotation = Quaternion.Euler(0, 90, 0);
            VolumeChange.Instance.vignette.center.value = new Vector2(0.5f, 0.5f);
            VolumeChange.Instance.vignette.intensity.value = 0;
            GameManager.Instance.enemy.SetActive(false);
            GameManager.Instance.flashlight.SetActive(true);
            GameManager.Instance.firstDoor.SetActive(true);
            GameManager.Instance.firstKey.SetActive(true);
            GameManager.Instance.note.SetActive(true);
            GameManager.Instance.note2.SetActive(true);
            GameManager.Instance.fog.SetActive(false);
            VolumeChange.Instance.volume.weight = 1f;
            OnClickManager.Instance.invisibleWall.SetActive(false);
            OnClickManager.Instance.invisibleWall2.SetActive(true);
            GameManager.Instance.fadeImage.DOFade(0, 4);
            GameManager.Instance.dayText.DOFade(0, 4);
            DOTween.Kill(GameManager.Instance.player);
            Invoke("KillDo", 4f);

        }

        private void KillDo()
        {
            controller = FindObjectsOfType<DrawerController>();
            chestController = FindObjectsOfType<ChestController>();
            doorController = FindObjectsOfType<ThemedKeyDoorController>();
            safeController = FindObjectOfType<SafeController>();
            if (TutorialManager.Instance.isFirst)
            {
                foreach (DrawerController d in controller)
                {
                    d.anim.Play(d.drawerCloseAnimation);
                    d.drawerState = DrawerController.DrawerState.Close;
                    InputSystems.Instance.drawer = false;
                }

                foreach (ChestController c in chestController)
                {
                    c.animator.speed = -1;
                    c.animator.Play("ChestAnim");
                    c.animator.SetBool("isRestart", false);
                    c.gameObject.tag = "Door";
                }

                foreach (ThemedKeyDoorController d in doorController)
                {
                    d.gameObject.GetComponent<GenericDoorOpen>().doorAnim.speed = -1;
                    d.gameObject.GetComponent<GenericDoorOpen>().doorAnim.Play(d.gameObject.GetComponent<GenericDoorOpen>().animationName);
                    d.gameObject.GetComponent<GenericDoorOpen>().doorAnim.SetBool("isRestart", false);
                    d.gameObject.tag = "Door";
                }
                safeController.safeModel.gameObject.GetComponent<Animator>().speed = -1;
                safeController.safeModel.gameObject.GetComponent<Animator>().Play("SafeDoorOpen", 0, 0.0f);
                safeController.safeAnim.SetBool("isRestart", false);
                safeController.gameObject.tag = "Padlock";
                safeController.safeBoxCollider.enabled = true;
            }
            DOTween.Kill(GameManager.Instance.fadeImage);
            DOTween.Kill(GameManager.Instance.dayText);
            GameManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
            GameManager.Instance.dayText.color = new Color(1, 1, 1, 1);
            GameManager.Instance.fadePanel.SetActive(false);
            GameManager.Instance.dayText.gameObject.SetActive(false);
            GameManager.Instance.controller.enabled = true;
            GameManager.Instance.walk.enabled = true;
            GameManager.Instance.playerInput.enabled = true;
            GameManager.Instance.walk.enabled = true;
        }
    }
}
