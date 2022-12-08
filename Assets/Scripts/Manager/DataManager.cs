using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using static DrawerController;

public class DataManager : SingleMonobehaviour<DataManager>
{
    [HideInInspector] public Transform[] originDrawerPos;
    [HideInInspector] public Transform[] originDoorPos;
    [HideInInspector] public Transform[] originChestPos;
    [HideInInspector] public GameObject originKatana;
    public InventoryObj inventoryObject;
    private DrawerController[] controller;

    private void Start()
    {
        originDrawerPos = GameManager.Instance.drawerChilds;
        originDoorPos = GameManager.Instance.doors;
        originChestPos = GameManager.Instance.chestChilds;
        originKatana = GameManager.Instance.katana;
        controller = FindObjectsOfType<DrawerController>();
    }


    public void RestartInit()
    {
        InputSystems.Instance.isPanel = true;
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.startSceneMusic;
        GameManager.Instance.backgroundmusic.Play();
        GameManager.Instance.endingPlayer.SetActive(false);
        inventoryObject.Clear();

        for(int i = 0; i < ItemRandomSpawn.Instance.spawnPos.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.spawnPos[i].GetComponentInChildren<GameObject>();
            Destroy(child);
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.spawnChestPos.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.spawnChestPos[i].GetComponentInChildren<GameObject>();
            Destroy(child);
        }

        for (int i = 0; i < ItemRandomSpawn.Instance.spawnBatteryPos.Length; i++)
        {
            GameObject child = ItemRandomSpawn.Instance.spawnBatteryPos[i].GetComponentInChildren<GameObject>();
            Destroy(child);
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
    }
}
