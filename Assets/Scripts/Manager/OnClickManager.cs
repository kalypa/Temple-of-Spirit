using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;
using DG.Tweening;
using UnityEngine.Windows;

public class OnClickManager : SingleMonobehaviour<OnClickManager>
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject notePanel1;
    [SerializeField] private GameObject notePanel2;
    [SerializeField] private GameObject notePanel3;
    [SerializeField] private GameObject notePanel4;
    [SerializeField] private GameObject notePanel5;
    [SerializeField] private GameObject notePanel6;
    [SerializeField] private GameObject notePanel7;
    [SerializeField] private GameObject notePanel8;
    [SerializeField] private GameObject notePanel9;
    [SerializeField] private GameObject notePanel10;
    [SerializeField] private GameObject notePanel11;
    [SerializeField] private GameObject notePanel12;
    [SerializeField] private GameObject notePanel13;
    [SerializeField] private GameObject notePanel14;
    [SerializeField] private GameObject notePanel15;
    [SerializeField] private GameObject note1;
    [SerializeField] private GameObject note2;
    [SerializeField] private GameObject note3;
    [SerializeField] private GameObject note4;
    [SerializeField] private GameObject note5;
    [SerializeField] private GameObject note6;
    [SerializeField] private GameObject note7;
    [SerializeField] private GameObject note8;
    [SerializeField] private GameObject note9;
    [SerializeField] private GameObject note10;
    [SerializeField] private GameObject note11;
    [SerializeField] private GameObject note12;
    [SerializeField] private GameObject note13;
    [SerializeField] private GameObject note14;
    [SerializeField] private GameObject note15;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Sprite sprite_sound_Off;
    [SerializeField] private Sprite sprite_sound_On;
    [SerializeField] private Image  sound_Current;
    [SerializeField] private string noteSound = "NoteOpen";
    [SerializeField] private GameObject playercamera;
    [SerializeField] private GameObject playerFirstPos;
    [SerializeField] private ItemRandomSpawn itemManager;
    [SerializeField] private PlayerRaycast playerRaycast;
    private InputSystems _input;
    public GameObject startPanel;
    public GameObject invisibleWall;
    public GameObject invisibleWall2;
    private float time = 4f;
    private void Start()
    {
        InputSystems.Instance.isPanel = true;
        GameManager.Instance.controller = GameManager.Instance.player.GetComponent<FirstPersonController>();
        GameManager.Instance.fadeImage = GameManager.Instance.fadePanel.GetComponent<Image>();
    }

    public void OnClickInvenQuit()
    {
        InputSystems.Instance.isInven = false;
        InputSystems.Instance.inven = false;
        inventory.SetActive(false);
    }
    public void OnClickStartButton()
    {
        GameManager.Instance.player.transform.position = playerFirstPos.transform.position;
        playercamera.transform.rotation = playerFirstPos.transform.rotation;
        invisibleWall2.SetActive(false);
        GameManager.Instance.ghost.transform.position = GameManager.Instance.enemyStartPos.position;
        GameManager.Instance.walk.enabled = false;
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.tutorialMusic;
        GameManager.Instance.backgroundmusic.Play();
        InputSystems.Instance.isPanel = false;
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.fog.SetActive(true);
        VolumeChange.Instance.volume.weight = 0.25f;
        invisibleWall.SetActive(true);
        GameManager.Instance.fadePanel.SetActive(true);
        startPanel.SetActive(false);
        GameManager.Instance.fadeImage.DOFade(0, time);
        TutorialManager.Instance.KeyTutorial();
        Invoke("KillDo", 4f);
        if (TutorialManager.Instance.isFirst)
        {
            GameManager.Instance.walk.enabled = true;
            PlayerLock();
        }
        itemManager.ItemSpawn();
        VolumeChange.Instance.vignette.center.value = new Vector2(0.5f, 0.5f);
        VolumeChange.Instance.vignette.intensity.value = 1;
    }
    private void KillDo()
    {
        DOTween.Kill(GameManager.Instance.fadeImage);
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
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
        note1.tag = "InteractiveObject";
        notePanel1.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit2()
    {
        InputSystems.Instance.isPanel = false;
        note2.tag = "InteractiveObject";
        notePanel2.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit3()
    {
        InputSystems.Instance.isPanel = false;
        note3.tag = "InteractiveObject";
        notePanel3.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit4()
    {
        InputSystems.Instance.isPanel = false;
        note4.tag = "InteractiveObject";
        notePanel4.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit5()
    {
        InputSystems.Instance.isPanel = false;
        note5.tag = "InteractiveObject";
        notePanel5.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit6()
    {
        InputSystems.Instance.isPanel = false;
        note6.tag = "InteractiveObject";
        notePanel6.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit7()
    {
        InputSystems.Instance.isPanel = false;
        note7.tag = "InteractiveObject";
        notePanel7.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit8()
    {
        InputSystems.Instance.isPanel = false;
        note8.tag = "InteractiveObject";
        notePanel8.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit9()
    {
        InputSystems.Instance.isPanel = false;
        note9.tag = "InteractiveObject";
        notePanel9.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnclickNoteQuit10()
    {
        InputSystems.Instance.isPanel = false;
        note10.tag = "InteractiveObject";
        notePanel10.SetActive(false);
        AudioManager.instance.Play(noteSound);
    }

    public void OnClickNextPageButton1()
    {
        notePanel2.SetActive(false);
        notePanel3.SetActive(true);
        AudioManager.instance.Play(noteSound);
    }

    public void OnClickNextPageButton2()
    {
        notePanel3.SetActive(false);
        notePanel4.SetActive(true);
        AudioManager.instance.Play(noteSound);
    }

    public void OnClickNextPageButton3()
    {
        notePanel4.SetActive(false);
        notePanel5.SetActive(true);
        AudioManager.instance.Play(noteSound);
    }
}
