using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemRandomSpawn : SingleMonobehaviour<ItemRandomSpawn>
{
    public Transform[] spawnPos;
    public Transform[] spawnChestPos;
    public Transform[] spawnBatteryPos;
    public GameObject[] keys;
    public GameObject[] chestkeys;
    public GameObject[] battery;
    private int start = 0, end = 41;
    private int start2 = 0, end2 = 14;
    private int start3 = 0, end3 = 55;
    public int[] notContain = new int[100];
    public int[] notContain2 = new int[100];
    public int[] notContain3 = new int[100];
    public HashSet<int> exclude;
    public void ItemSpawn()
    {
        DoorKeySpawn();
        ChestKeySpawn();
        BatterySpawn();
    }

    private void DoorKeySpawn()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            GameObject[] clone = null;
            int random = GetRandomNotContain(start, end, notContain);
            notContain[i] = random;
            if(clone[i] == null)
            {
                clone[i] = Instantiate(keys[i], spawnPos[random].position, Quaternion.identity);
            }
            else
            {
                clone[i].transform.position = spawnPos[random].position;
                clone[i].transform.rotation = Quaternion.identity;
                clone[i].SetActive(true);
            }
            DeleteString(keys[i]);
            clone[i].transform.rotation = Quaternion.Euler(keys[i].transform.rotation.x, keys[i].transform.rotation.y, 180);
            clone[i].transform.SetParent(spawnPos[random]);
        }
    }

    private void ChestKeySpawn()
    {
        for (int i = 0; i < chestkeys.Length; i++)
        {
            GameObject[] clone = null;
            int random = GetRandomNotContain(start2, end2, notContain2);
            notContain2[i] = random;
            if (clone[i] == null)
            {
                clone[i] = Instantiate(chestkeys[i], spawnChestPos[random].position, Quaternion.identity);

            }
            else
            {
                clone[i].transform.position = spawnChestPos[random].position;
                clone[i].transform.rotation = Quaternion.identity;
                clone[i].SetActive(true);
            }
            DeleteString(chestkeys[i]);
            clone[i].transform.SetParent(spawnChestPos[random]);
        }
    }
    private void BatterySpawn()
    {
        for(int i = 0; i < battery.Length; i++)
        {
            GameObject[] clone = null;
            int random = GetRandomNotContain(start3, end3, notContain3);
            notContain3[i] = random;
            if (clone[i] == null)
            {
                clone[i] = Instantiate(battery[i], spawnBatteryPos[random].position, Quaternion.identity);
            }
            else
            {
                clone[i].transform.position = spawnBatteryPos[random].position;
                clone[i].transform.rotation = Quaternion.identity;
                clone[i].SetActive(true);
            }
            DeleteString(battery[i]);
            clone[i].transform.SetParent(spawnBatteryPos[random]);
        }
    }

    public int GetRandomNotContain(int min, int max, int[] notContainValue)
    {
        exclude = new HashSet<int>();
        for (int i = 0; i < notContainValue.Length; i++)
        {
            exclude.Add(notContainValue[i]);
        }
        for(int i = 0; i < notContainValue.Length; i++)
        {
            exclude.Remove(notContainValue[i]);
        }
        var range = Enumerable.Range(min, max).Where(i => !exclude.Contains(i));
        var random = new System.Random();
        int index = random.Next(min, max - exclude.Count);
        return range.ElementAt(index);
    }

    private void DeleteString(GameObject k)
    {
        int index = k.name.IndexOf("(Clone)");
        if (index > 0)
        {
            k.name = k.name.Substring(0, index);
        }
    }
}
