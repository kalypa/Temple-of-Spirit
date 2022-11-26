using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class OnClickManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject notePanel1;
    [SerializeField] private GameObject notePanel2;
    [SerializeField] private GameObject notePanel3;
    [SerializeField] private GameObject notePanel4;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Sprite sprite_sound_Off;
    [SerializeField] private Sprite sprite_sound_On;
    [SerializeField] private Image  sound_Current;
    [SerializeField] private string noteSound = "NoteOpen";
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerFirstPos;
    [SerializeField] private GameObject invisibleWall;
    [SerializeField] private GameObject mapPrefab;
    [SerializeField] private GameObject fog;
    [SerializeField] private Volume volumeObject;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private Image fadeImage;
    private FirstPersonController controller;
    private void Awake()
    {
        InputSystems.Instance.isPanel = true;
        controller = player.GetComponent<FirstPersonController>(); 
        fadeImage = fadePanel.GetComponent<Image>();
    }

    public void OnClickInvenQuit()
    {
        InputSystems.Instance.isInven = false;
        InputSystems.Instance.inven = false;
        inventory.SetActive(false);
    }
    public void OnClickStartButton()
    {
        InputSystems.Instance.isPanel = false;
        controller.enabled = false;
        //GameObject Map = Instantiate(mapPrefab);
        player.transform.position = playerFirstPos.transform.position;
        fog.SetActive(true);
        volumeObject.weight = 0.25f;
        controller.enabled = true;
        invisibleWall.SetActive(true);
        fadePanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void OnClickSettingButton()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnClickCloseButtonSetting()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickSoundButton()
    {

        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        if(AudioListener.volume <= 0)
        {

            sound_Current.sprite = sprite_sound_Off;
        }
        else if(AudioListener.volume > 0f)
        {
            sound_Current.sprite = sprite_sound_On;
        }
    }

    public void OnclickNoteQuit1()
    {
        InputSystems.Instance.isPanel = false;
        notePanel1.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }
}
