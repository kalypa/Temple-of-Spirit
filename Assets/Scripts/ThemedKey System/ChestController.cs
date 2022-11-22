using AdventurePuzzleKit;
using System.Collections;
using System.Collections.Generic;
using ThemedKeySystem;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animation anim;

    [SerializeField] private ChestType _chestType = ChestType.None;
    [SerializeField] private string doorOpenSound = "ThemedKeyDoorOpen";
    [SerializeField] private string lockedDoorSound = "ThemedKeyLockedDoor";
    private enum ChestType { None, RedChest, BlueChest }
    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void CheckChest()
    {
        switch (_chestType)
        { 
            case ChestType.RedChest:
                if (ThemedKeyInventoryController.instance.hasRedKey)
                {
                    StartCoroutine(PlayAnimation());
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
        AKAudioManager.instance.Play(doorOpenSound);
    }

    public void LockedDoorSound()
    {
        AKAudioManager.instance.Play(lockedDoorSound);
    }
}
