using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : SingleMonobehaviour<DataManager>
{
    [HideInInspector] public Transform[] originDrawerPos;
    [HideInInspector] public Transform[] originDoorPos;
    [HideInInspector] public Transform[] originChestPos;
    [HideInInspector] public GameObject originKatana;

    private void Start()
    {
        originDrawerPos = GameManager.Instance.drawerChilds;
        originDoorPos = GameManager.Instance.doors;
        originChestPos = GameManager.Instance.chestChilds;
        originKatana = GameManager.Instance.katana;
    }

    public void RestartInit()
    {
        GameManager.Instance.drawerChilds = originDrawerPos;
        GameManager.Instance.doors = originDoorPos;
        GameManager.Instance.chestChilds = originChestPos;
        GameManager.Instance.katana = originKatana;
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
