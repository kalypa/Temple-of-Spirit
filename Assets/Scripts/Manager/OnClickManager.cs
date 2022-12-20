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
using ItemInven;

public class OnClickManager : SingleMonobehaviour<OnClickManager>
{
    [SerializeField] private GameObject inventory;
    public GameObject notePanel1;
    public GameObject notePanel2;
    public GameObject notePanel3;
    public GameObject notePanel4;
    public GameObject notePanel5;
    public GameObject notePanel6;
    public GameObject notePanel7;
    public GameObject notePanel8;
    public GameObject notePanel9;
    public GameObject notePanel10;
    public GameObject notePanel11;
    public GameObject notePanel12;
    public GameObject notePanel13;
    public GameObject notePanel14;
    public GameObject notePanel15;
    public GameObject note1;
    public GameObject note2;
    public GameObject note3;
    public GameObject note4;
    public GameObject note5;
    public GameObject note6;
    public GameObject note7;
    public GameObject note8;
    public GameObject note9;
    public GameObject note10;
    public GameObject note11;
    public GameObject note12;
    public GameObject note13;
    public GameObject note14;
    public GameObject note15;
    public GameObject batteryUI;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private string noteSound = "NoteOpen";
    [SerializeField] private GameObject playercamera;
    [SerializeField] private GameObject playerFirstPos;
    [SerializeField] private ItemRandomSpawn itemManager;
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
        InputSystems.Instance.isPanel = false;
        inventory.SetActive(false);
    }
    public void OnClickStartButton()
    {
        GameManager.Instance.backgroundmusic.Stop(); 
        GameManager.Instance.player.transform.position = playerFirstPos.transform.position;
        playercamera.transform.eulerAngles = playerFirstPos.transform.eulerAngles;
        invisibleWall2.SetActive(false);
        GameManager.Instance.ghost.transform.position = GameManager.Instance.enemyStartPos.position;
        GameManager.Instance.walk.enabled = false;
        InputSystems.Instance.isPanel = false;
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.fog.SetActive(true);
        VolumeChange.Instance.volume.weight = 0.25f;
        invisibleWall.SetActive(true);
        GameManager.Instance.fadePanel.SetActive(true);
        startPanel.SetActive(false);
        Fade();
        Invoke("KillDo", 4f);
        itemManager.ItemSpawn();
        VolumeChange.Instance.vignette.center.value = new Vector2(0.5f, 0.5f);
        VolumeChange.Instance.vignette.intensity.value = 1;
    }

    private void Fade()
    {
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.tutorialMusic;
        GameManager.Instance.backgroundmusic.Play();
        TutorialText.Instance.textUI.gameObject.SetActive(false);
        GameManager.Instance.fadeImage.DOFade(0, time);
        GameManager.Instance.playerInput.enabled = false;
        if (TutorialManager.Instance.isFirst == false)
        {
            TutorialManager.Instance.KeyTutorial();
        }
        else if(TutorialManager.Instance.isFirst == true)
        {
            PlayerLock();
        }
    }

    private void KillDo()
    {
        DOTween.Kill(GameManager.Instance.fadeImage);
        GameManager.Instance.fadePanel.SetActive(false);
        GameManager.Instance.fadeImage.color = new Color(0, 0, 0, 1);
    }

    private void PlayerLock()
    {
        GameManager.Instance.player.SetActive(true);
        InputSystems.Instance.isPanel = false;
        GameManager.Instance.walk.enabled = true;
        GameManager.Instance.playerInput.enabled = true;
        GameManager.Instance.controller.enabled = true;
    }

    public void OnClickContinueButton()
    {
        InputSystems.Instance.pause = false;
        InputSystems.Instance.isPause = false;
        InputSystems.Instance.isPanel = false;
        pausePanel.SetActive(false);
        GameManager.Instance.walk.volume = 1f;
        Time.timeScale = 1;
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
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
