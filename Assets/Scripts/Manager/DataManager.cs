using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using static DrawerController;
using ItemInven;

public class DataManager : SingleMonobehaviour<DataManager>
{
    private ChestController[] chestController;
    public InventoryObj inventoryObject;
    private ThemedKeyDoorController[] doorController;
    private SafeController safeController;
    public bool isRestart = false;
    private void Start()
    {
        chestController = FindObjectsOfType<ChestController>();
        safeController = FindObjectOfType<SafeController>();
        doorController = FindObjectsOfType<ThemedKeyDoorController>();
    }

    public void RestartInit()
    {
        GameManager.Instance.endingPlayer.SetActive(false);
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.startSceneMusic;
        GameManager.Instance.backgroundmusic.Play();
        inventoryObject.Clear();

        for(int i = 0; i < ItemRandomSpawn.Instance.keys.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.keys[i];
            child.SetActive(false);
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.chestkeys.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.chestkeys[i];
            child.SetActive(false);
        }

        for(int i = 0; i < ItemRandomSpawn.Instance.battery.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.battery[i];
            child.SetActive(false);
        }
        safeController.SafeUIFalse();
        GameManager.Instance.sacredSword.SetActive(true);
        EndingItemController.Instance.sword.SetActive(false);
        EndingItemController.Instance.grtar.SetActive(false);
        EndingItemController.Instance.halgr.SetActive(false);
        GameManager.Instance.flashlight.SetActive(false);
        GameManager.Instance.firstDoor.SetActive(false);
        GameManager.Instance.firstKey.SetActive(false);
        GameManager.Instance.note.SetActive(false);
        GameManager.Instance.note2.SetActive(false);
        for (int i = 0; i < ItemRandomSpawn.Instance.notContain.Length; i++)
        {
            ItemRandomSpawn.Instance.exclude.Remove(ItemRandomSpawn.Instance.notContain[i]);
        }
        for (int i = 0; i < ItemRandomSpawn.Instance.notContain2.Length; i++)
        {
            ItemRandomSpawn.Instance.exclude.Remove(ItemRandomSpawn.Instance.notContain2[i]);
        }
        for (int i = 0; i < ItemRandomSpawn.Instance.notContain3.Length; i++)
        {
            ItemRandomSpawn.Instance.exclude.Remove(ItemRandomSpawn.Instance.notContain3[i]);
        }
        GameManager.Instance.hasHeartKey = false;
        GameManager.Instance.endingItem1.SetActive(true);
        GameManager.Instance.endingItem2.SetActive(true);
        GameManager.Instance.endingItem3.SetActive(true);
        GameManager.Instance.hasDiamondKey = false;
        GameManager.Instance.hasSpadeKey = false;
        GameManager.Instance.hasClubKey = false;
        GameManager.Instance.hasRedKey = false;
        GameManager.Instance.hasBlueKey = false;
        GameManager.Instance.hasFirstKey = false;
        GameManager.Instance.hasGrtar = false;
        GameManager.Instance.hasHalgr = false;
        GameManager.Instance.hasBattery = false;
        GameManager.Instance.hasSword = false;
        GameManager.Instance.hasSacredSword = false;
        GameManager.Instance.hasFlashLight = false;
        InputSystems.Instance.flash = false;
        InputSystems.Instance.isFlash = false;
        GameManager.Instance.flashLight.enabled = false;
        GameManager.Instance.playerDeathStack = 1;
        VolumeChange.Instance.vignette.intensity.value = 1;
        GameManager.Instance.battery.value = 1;
        OnClickManager.Instance.batteryUI.SetActive(false);
    }
}
