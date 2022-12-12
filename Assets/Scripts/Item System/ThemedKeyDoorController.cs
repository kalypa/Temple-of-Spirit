using ItemSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using InputSystem;
namespace ItemInven
{
    public class ThemedKeyDoorController : MonoBehaviour
    {
        [Header("Door Properties")]
        [SerializeField] private DoorType _doorType = DoorType.None;
        private enum DoorType { None, HeartDoor, DiamondDoor, SpadeDoor, CloverDoor, FirstDoor }

        [SerializeField] private GameObject animatedDoorKey = null;

        [Header("Sound Delays - Edit to increase delay")]
        [SerializeField] private float keyAudioDelay = 0.5f;
        [SerializeField] private float doorOpenDelay = 1.5f;

        [Header("Key Animation Name")]
        [SerializeField] private string keyAnimation = "HeartKey_Anim_Unlock";

        [Header("Door Sounds")]
        [SerializeField] private string doorOpenSound = "ThemedKeyDoorOpen";
        [SerializeField] private string lockedDoorSound = "ThemedKeyLockedDoor";
        [SerializeField] private string unlockDoorSound = "ThemedKeyInsertKey";

        [Header("Animation Event")]
        [SerializeField] private UnityEvent onUnlock = null;
        [SerializeField] private Text lockedDoorText = null;

        private Animator anim;

        private void Start()
        {
            anim = animatedDoorKey.GetComponent<Animator>();
        }

        public void CheckDoor()
        {
            switch (_doorType)
            {
                case DoorType.HeartDoor:
                    if (GameManager.Instance.hasHeartKey)
                    {
                        StartCoroutine(PlayAnimation());
                        ThemedKeyInventoryController.Instance.DeleteInventory("Heart");
                    }
                    else
                    {
                        StartCoroutine(DoorLockedText());
                        LockedDoorSound();
                    }
                    break;
                case DoorType.DiamondDoor:
                    if (GameManager.Instance.hasDiamondKey)
                    {
                        StartCoroutine(PlayAnimation());
                        ThemedKeyInventoryController.Instance.DeleteInventory("Diamond");
                    }
                    else
                    {
                        StartCoroutine(DoorLockedText());
                        LockedDoorSound();
                    }
                    break;
                case DoorType.CloverDoor:
                    if (GameManager.Instance.hasClubKey)
                    {
                        StartCoroutine(PlayAnimation());
                        ThemedKeyInventoryController.Instance.DeleteInventory("Club");
                    }
                    else
                    {
                        StartCoroutine(DoorLockedText());
                        LockedDoorSound();
                    }
                    break;
                case DoorType.SpadeDoor:
                    if (GameManager.Instance.hasSpadeKey)
                    {                      
                        StartCoroutine(PlayAnimation());
                        ThemedKeyInventoryController.Instance.DeleteInventory("Spade");
                    }
                    else
                    {
                        StartCoroutine(DoorLockedText());
                        LockedDoorSound();
                    }
                    break;
                case DoorType.FirstDoor:
                    if (GameManager.Instance.hasFirstKey)
                    {
                        StartCoroutine(PlayAnimation());
                        ThemedKeyInventoryController.Instance.DeleteInventory("First");
                        GameManager.Instance.ghost.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(DoorLockedText());
                        LockedDoorSound();
                    }
                    break;
            }
        }

        public IEnumerator PlayAnimation()
        {
            gameObject.tag = "Untagged";
            animatedDoorKey.SetActive(true);
            anim.Play(keyAnimation, 0, 0.0f);
            yield return new WaitForSeconds(keyAudioDelay);
            UnlockSound();
            yield return new WaitForSeconds(doorOpenDelay);

            animatedDoorKey.SetActive(false);
            onUnlock.Invoke();
            DoorOpenSound();            
        }
        private IEnumerator DoorLockedText()
        {
            lockedDoorText.text = animatedDoorKey.name + "가 필요합니다";
            lockedDoorText.gameObject.SetActive(true);
            lockedDoorText.DOFade(0, 1f);
            InputSystems.Instance.pickup = false;
            yield return new WaitForSeconds(1f);
            lockedDoorText.gameObject.SetActive(false);
            lockedDoorText.color = new Color(1, 1, 1, 1);
        }
        public void DoorOpenSound()
        {
            AudioManager.instance.Play(doorOpenSound);
        }

        public void LockedDoorSound()
        {
            AudioManager.instance.Play(lockedDoorSound);
        }

        public void UnlockSound()
        {
            AudioManager.instance.Play(unlockDoorSound);
        }
    }
}
