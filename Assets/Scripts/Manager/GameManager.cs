using Cinemachine;
using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using DG.Tweening;
using UnityEngine.InputSystem;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public List<int> playerHPData = new List<int>();
    public List<bool> hasItemData = new List<bool>();
    public List<Transform[]> objectData = new List<Transform[]>();
    public List<GameObject> katanaData = new List<GameObject>();
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
    public PlayerInput playerInput;
    public GameObject drawers;
    public Transform[] drawerChilds;
    public Transform[] doors;
    public GameObject chests;
    public Transform[] chestChilds;
    public GameObject katana;
    [HideInInspector] public bool hasHeartKey;
    [HideInInspector] public bool hasDiamondKey;
    [HideInInspector] public bool hasSpadeKey;
    [HideInInspector] public bool hasClubKey;
    [HideInInspector] public bool hasRedKey;
    [HideInInspector] public bool hasBlueKey;
    [HideInInspector] public bool hasGrtar;
    [HideInInspector] public bool hasHalgr;
    [HideInInspector] public bool hasBattery;
    [HideInInspector] public bool hasSword;
    [HideInInspector] public bool hasSacredSword;
    [HideInInspector] public bool hasFlashLight;
    [HideInInspector] public bool isAtk;
    public float playerDeathStack = 1;

    private void Start()
    {
        ObjectInit(drawers, drawerChilds);
        ObjectInit(chests, chestChilds);
    }

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

    private void ObjectInit(GameObject g, Transform[] t)
    {
        for (int i = 0; i < g.transform.childCount; i++)
        {
            t[i] = g.transform.GetChild(i);
        }
    }
}
