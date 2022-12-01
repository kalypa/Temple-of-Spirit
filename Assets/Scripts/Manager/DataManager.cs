using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public List<int> playerHPData = new List<int>();
    public List<bool> hasItemData = new List<bool>();
    public List<Transform[]> objectData = new List<Transform[]>();
    public List<GameObject> katanaData = new List<GameObject>();
    public int playerDeathStack;
    public bool hasHeartKey;
    public bool hasDiamondKey;
    public bool hasSpadeKey;
    public bool hasClubKey;
    public bool hasRedKey;
    public bool hasBlueKey;
    public bool hasGrtar;
    public bool hasHalgr;
    public bool hasBattery;
    public bool hasSword;
    public bool hasSacredSword;
    public bool hasFlashLight;
    public Transform[] drawerChilds;
    public Transform[] doors;
    public Transform[] chestChilds;
    public GameObject katana;
}

public class DataManager : MonoBehaviour
{
    string path;

    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            GameManager.Instance.playerDeathStack = 1;
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
            //SaveData();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                for (int i = 0; i < saveData.playerHPData.Count; i++)
                {
                    GameManager.Instance.playerHPData.Add(saveData.playerHPData[i]);
                }
                for (int i = 0; i < saveData.hasItemData.Count; i++)
                {
                    GameManager.Instance.hasItemData.Add(saveData.hasItemData[i]);
                }
                for (int i = 0; i < saveData.objectData.Count; i++)
                {
                    GameManager.Instance.objectData.Add(saveData.objectData[i]);
                }
                for (int i = 0; i < saveData.katanaData.Count; i++)
                {
                    GameManager.Instance.katanaData.Add(saveData.katanaData[i]);
                }
                GameManager.Instance.playerDeathStack = saveData.playerDeathStack;
                GameManager.Instance.hasHeartKey = saveData.hasHeartKey;
                GameManager.Instance.hasDiamondKey = saveData.hasDiamondKey;
                GameManager.Instance.hasSpadeKey = saveData.hasSpadeKey;
                GameManager.Instance.hasClubKey = saveData.hasClubKey;
                GameManager.Instance.hasRedKey = saveData.hasRedKey;
                GameManager.Instance.hasBlueKey = saveData.hasBlueKey;
                GameManager.Instance.hasGrtar = saveData.hasGrtar;
                GameManager.Instance.hasHalgr = saveData.hasHalgr;
                GameManager.Instance.hasBattery = saveData.hasBattery;
                GameManager.Instance.hasSword = saveData.hasSword;
                GameManager.Instance.hasSacredSword = saveData.hasSacredSword;
                GameManager.Instance.drawerChilds = saveData.drawerChilds;
                GameManager.Instance.doors = saveData.doors;
                GameManager.Instance.chestChilds = saveData.chestChilds;
                GameManager.Instance.katana = saveData.katana;
            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        //for (int i = 0; i < 10; i++)
        //{
        //    saveData.playerHPData.Add(i);
        //}
        //
        //for (int i = 0; i < 10; i++)
        //{
        //    saveData.hasItemData.Add(i);
        //}

        GameManager.Instance.playerDeathStack = saveData.playerDeathStack;
        GameManager.Instance.hasHeartKey = saveData.hasHeartKey;
        GameManager.Instance.hasDiamondKey = saveData.hasDiamondKey;
        GameManager.Instance.hasSpadeKey = saveData.hasSpadeKey;
        GameManager.Instance.hasClubKey = saveData.hasClubKey;
        GameManager.Instance.hasRedKey = saveData.hasRedKey;
        GameManager.Instance.hasBlueKey = saveData.hasBlueKey;
        GameManager.Instance.hasGrtar = saveData.hasGrtar;
        GameManager.Instance.hasHalgr = saveData.hasHalgr;
        GameManager.Instance.hasBattery = saveData.hasBattery;
        GameManager.Instance.hasSword = saveData.hasSword;
        GameManager.Instance.hasSacredSword = saveData.hasSacredSword;
        GameManager.Instance.drawerChilds = saveData.drawerChilds;
        GameManager.Instance.doors = saveData.doors;
        GameManager.Instance.chestChilds = saveData.chestChilds;
        GameManager.Instance.katana = saveData.katana;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }
}
