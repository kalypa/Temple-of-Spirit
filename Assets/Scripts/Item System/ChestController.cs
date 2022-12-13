using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using ItemInven;
using UnityEngine;
using UnityEngine.UI;
using InputSystem;
using DG.Tweening;
public class ChestController : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private ChestType _chestType = ChestType.None;
    [SerializeField] private string doorOpenSound = "ThemedKeyDoorOpen";
    [SerializeField] private string lockedDoorSound = "ThemedKeyLockedDoor";
    private MeshCollider colliders;
    [SerializeField] private GameObject collideFixObj;
    [SerializeField] private Text lockedDoorText = null;
    private enum ChestType { None, Red, Blue }
    private void Start()
    {
        animator = GetComponent<Animator>();
        colliders = GetComponent<MeshCollider>();
    }

    public void CheckChest()
    {
        switch (_chestType)
        { 
            case ChestType.Red:
                if (GameManager.Instance.hasRedKey)
                {
                    StartCoroutine(PlayAnimation());
                    colliders.enabled = false;
                    collideFixObj.SetActive(true);
                    ThemedKeyInventoryController.Instance.DeleteInventory("Red");
                }
                else
                {
                    StartCoroutine(DoorLockedText());
                    LockedDoorSound();
                }
                break;
            case ChestType.Blue:
                if (GameManager.Instance.hasBlueKey)
                {
                    StartCoroutine(PlayAnimation());
                    colliders.enabled = false;
                    collideFixObj.SetActive(true);
                    ThemedKeyInventoryController.Instance.DeleteInventory("Blue");
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
        animator.Play("ChestAnim");
        DoorOpenSound();
        yield return null;
    }
    public void DoorOpenSound()
    {
        AudioManager.instance.Play(doorOpenSound);
    }

    private IEnumerator DoorLockedText()
    {
        lockedDoorText.text = _chestType.ToString() + "Key가 필요합니다";
        lockedDoorText.gameObject.SetActive(true);
        lockedDoorText.DOFade(0, 1f);
        InputSystems.Instance.pickup = false;
        yield return new WaitForSeconds(1f);
        lockedDoorText.gameObject.SetActive(false);
        lockedDoorText.color = new Color(1, 1, 1, 1);
    }

    public void LockedDoorSound()
    {
        AudioManager.instance.Play(lockedDoorSound);
    }
}
