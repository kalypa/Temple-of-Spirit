using Cinemachine;
using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using DG.Tweening;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public GameObject fog;
    public GameObject fadePanel;
    [HideInInspector] public Image fadeImage;
    public GameObject player;
    [HideInInspector] public FirstPersonController controller;
    public Transform startPos;
    public GameObject enemy;
    public GameObject ghost;
    public GameObject flashlight;
    public GameObject note;
    public GameObject note2;
    public AudioClip startSceneMusic;
    public AudioClip tutorialMusic;
    public AudioClip mainMusic;
    public AudioClip escapeMusic;
    public AudioSource backgroundmusic;
    public CinemachineVirtualCamera deadCam;
    public CinemachineVirtualCamera playerCam;
    //public cinemachine
    [HideInInspector] public bool isAtk;
    public float playerHP = 3;

    public void Restart()
    {
        StartCoroutine(GetAtk());
    }
    private IEnumerator GetAtk()
    {
        fadePanel.SetActive(true);
        fadeImage.DOFade(0, 4);
        yield return new WaitForSeconds(4f);
        controller.enabled = true;
        DOTween.Kill(fadeImage);
        fadePanel.SetActive(false);
        fadeImage.color = new Color(0, 0, 0, 1);
    }
}
