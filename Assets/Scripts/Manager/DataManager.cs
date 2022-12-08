using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using static DrawerController;

public class DataManager : SingleMonobehaviour<DataManager>
{
    public InventoryObj inventoryObject;
    private DrawerController[] controller;

    private void Start()
    {
        controller = FindObjectsOfType<DrawerController>();
    }

    public void RestartInit()
    {
        InputSystems.Instance.isPanel = true;
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.startSceneMusic;
        GameManager.Instance.backgroundmusic.Play();
        inventoryObject.Clear();

        for(int i = 0; i < ItemRandomSpawn.Instance.spawnPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnPos[i].childCount != 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnPos[i].GetChild(0).gameObject;
                Destroy(child);
            }
            else
                continue;
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.spawnChestPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnPos[i].childCount != 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnChestPos[i].GetChild(0).gameObject;
                Destroy(child);
            }
            else
                continue;
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.spawnBatteryPos.Length; i++)
        {
            if (ItemRandomSpawn.Instance.spawnPos[i].childCount > 0)
            {
                GameObject child = ItemRandomSpawn.Instance.spawnBatteryPos[i].GetChild(0).gameObject;
                Destroy(child);
            }
            else
                continue;
        }

        for(int i = 0; i < controller.Length; i++)
        {
            controller[i].drawerState = DrawerState.Close;
        }

        GameManager.Instance.sacredSword.SetActive(true);
        EndingItemController.Instance.sword.SetActive(false);
        EndingItemController.Instance.grtar.SetActive(false);
        EndingItemController.Instance.halgr.SetActive(false);
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
        GameManager.Instance.playerDeathStack = 1;
        GameManager.Instance.endingPlayer.SetActive(false);
    }
}
