using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;

    public void OnClickInvenQuit()
    {
        inventory.SetActive(false);     
    }
}
