using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using ItemInven;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animation anim;

    [SerializeField] private ChestType _chestType = ChestType.None;
    [SerializeField] private string doorOpenSound = "ThemedKeyDoorOpen";
    [SerializeField] private string lockedDoorSound = "ThemedKeyLockedDoor";
    private MeshCollider colliders;
    [SerializeField] private GameObject collideFixObj;
    private enum ChestType { None, RedChest, BlueChest }
    private void Start()
    {
        anim = GetComponent<Animation>();
        colliders = GetComponent<MeshCollider>();
    }

    public void CheckChest()
    {
        switch (_chestType)
        { 
            case ChestType.RedChest:
                if (ThemedKeyInventoryController.instance.hasRedKey)
                {
                    StartCoroutine(PlayAnimation());
                    colliders.enabled = false;
                    collideFixObj.SetActive(true);
                }
                else
                {
                    LockedDoorSound();
                }
                break;
            case ChestType.BlueChest:
                if (ThemedKeyInventoryController.instance.hasBlueKey)
                {
                    StartCoroutine(PlayAnimation());
                    colliders.enabled = false;
                    collideFixObj.SetActive(true);
                }
                else
                {
                    LockedDoorSound();
                }
                break;
        }

    }

    public IEnumerator PlayAnimation()
    {
        gameObject.tag = "Untagged";
        anim.Play();
        DoorOpenSound();
        yield return null;
    }
    public void DoorOpenSound()
    {
        AudioManager.instance.Play(doorOpenSound);
    }

    public void LockedDoorSound()
    {
        AudioManager.instance.Play(lockedDoorSound);
    }
}
