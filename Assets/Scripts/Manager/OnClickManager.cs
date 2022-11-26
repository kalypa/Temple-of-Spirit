using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using DG.Tweening;

public class OnClickManager : SingleMonobehaviour<OnClickManager>
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
    [SerializeField] private GameObject playercamera;
    [SerializeField] private GameObject playerFirstPos;
    [SerializeField] private GameObject invisibleWall;
    private Image fadeImage;
    private float time = 4f;
    private void Start()
    {
        InputSystems.Instance.isPanel = true;
        GameManager.Instance.controller = GameManager.Instance.player.GetComponent<FirstPersonController>(); 
        fadeImage = GameManager.Instance.fadePanel.GetComponent<Image>();
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
        //GameManager.Instance.controller.enabled = false;
        //GameObject Map = Instantiate(GameManager.Instance.mapPrefab);
        //GameManager.Instance.player.transform.position = playerFirstPos.transform.position;
        //playercamera.transform.rotation = playerFirstPos.transform.rotation;
        //GameManager.Instance.fog.SetActive(true);
        //VolumeChange.Instance.volume.weight = 0.25f;
        //invisibleWall.SetActive(true);
        //GameManager.Instance.fadePanel.SetActive(true);
        startPanel.SetActive(false);
        //fadeImage.DOFade(0, time);
        //PlayerLock();
    }
    private void PlayerLock()
    {
        GameManager.Instance.controller.enabled = true;
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
