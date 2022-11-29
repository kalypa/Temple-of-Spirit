using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemRandomSpawn : SingleMonobehaviour<ItemRandomSpawn>
{
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private Transform[] spawnChestPos;
    [SerializeField] private Transform[] spawnBatteryPos;
    [SerializeField] private GameObject[] keys;
    [SerializeField] private GameObject[] chestkeys;
    [SerializeField] private GameObject[] battery;
    private Transform spawnDoorKey;
    private Transform spawnChestKey;
    private Transform spawnBattery;
    private int start = 0, end = 41;
    private int start2 = 0, end2 = 14;
    private int start3 = 0, end3 = 55;
    private int[] notContain = new int[100];
    private int[] notContain2 = new int[100];
    private int[] notContain3 = new int[100];
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
            int random = Random.Range(start, end);
            spawnDoorKey = spawnPos[random];
            keys[i] = Instantiate(keys[i], spawnDoorKey.position, Quaternion.identity);
            DeleteString(keys[i]);  
            keys[i].transform.rotation = Quaternion.Euler(keys[i].transform.rotation.x, keys[i].transform.rotation.y, 180);
            keys[i].transform.SetParent(spawnDoorKey);
            notContain[i] = random;
            GetRandomNotContain(start, end, notContain);
        }
    }

    private void ChestKeySpawn()
    {
        for (int i = 0; i < chestkeys.Length; i++)
        {
            int random = Random.Range(start2, end2);
            spawnChestKey = spawnChestPos[random];
            chestkeys[i] = Instantiate(chestkeys[i], spawnChestKey.position, Quaternion.identity);
            DeleteString(chestkeys[i]);
            chestkeys[i].transform.SetParent(spawnChestKey);
            notContain2[i] = random;
            GetRandomNotContain(start2, end2, notContain2);
        }
    }
    private void BatterySpawn()
    {
        for(int i = 0; i < battery.Length; i++)
        {
            int random = Random.Range(start3, end3);
            spawnBattery = spawnBatteryPos[random];
            battery[i] = Instantiate(battery[i], spawnBattery.position, Quaternion.identity);
            DeleteString(battery[i]);
            battery[i].transform.SetParent(spawnBattery);
            notContain3[i] = random;
            GetRandomNotContain(start3, end3, notContain3);
        }
    }

    public int GetRandomNotContain(int min, int max, int[] notContainValue)
    {
        HashSet<int> exclude = new HashSet<int>();
        for (int i = 0; i < notContainValue.Length; i++)
        {
            exclude.Add(notContainValue[i]);
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
