using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject startPanel;
    public void OnClickInvenQuit()
    {
        InputSystems.Instance.isInven = false;
        InputSystems.Instance.inven = false;
        inventory.SetActive(false);
    }
    public void OnClickStartButton()
    {
        startPanel.SetActive(false);
    }

    public void OnClickSettingButton()
    {

    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
