using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;

    public void OnClickInvenQuit()
    {
        InputSystems.Instance.isInven = false;
        InputSystems.Instance.inven = false;
        inventory.SetActive(false);
    }

    public void OnClickPauseSettingButton()
    {
        
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MountainScene");
    }
    public void OnClickSettingButton()
    {

    }
    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
