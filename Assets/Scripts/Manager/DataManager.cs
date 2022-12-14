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

    private void Start()
    {
        chestController = FindObjectsOfType<ChestController>();
        safeController = FindObjectOfType<SafeController>();
        doorController = FindObjectsOfType<ThemedKeyDoorController>();
    }

    public void RestartInit()
    {
        GameManager.Instance.endingPlayer.SetActive(false);
        InputSystems.Instance.isPanel = true;
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.startSceneMusic;
        GameManager.Instance.backgroundmusic.Play();
        inventoryObject.Clear();

        for(int i = 0; i < ItemRandomSpawn.Instance.spawnPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnPos[i].childCount != 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnPos[i].GetChild(0).gameObject;
                child.SetActive(false);
            }
            else
                continue;
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.spawnChestPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnChestPos[i].childCount != 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnChestPos[i].GetChild(0).gameObject;
                child.SetActive(false);
            }
            else
                continue;
        }

        for(int i = 0; i < ItemRandomSpawn.Instance.spawnBatteryPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnBatteryPos[i].childCount != 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnBatteryPos[i].GetChild(0).gameObject;
                child.SetActive(false);
            }
            else
                continue;
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
        ItemRandomSpawn.Instance.notContain = new int[100];
        ItemRandomSpawn.Instance.notContain2 = new int[100];
        ItemRandomSpawn.Instance.notContain3 = new int[100];
        GameManager.Instance.hasHeartKey = false;
        GameManager.Instance.hasDiamondKey = false;
        GameManager.Instance.hasSpadeKey = false;
        GameManager.Instance.hasClubKey = false;
        GameManager.Instance.hasRedKey = false;
        GameManager.Instance.hasBlueKey = false;
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
    }
}
