using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
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
    public void OnClickInvenQuit()
    {
        //InputSystems.Instance.isInven = false;
        //InputSystems.Instance.inven = false;
        //inventory.SetActive(false);
    }
    public void OnClickStartButton()
    {
        //startPanel.SetActive(false);
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
