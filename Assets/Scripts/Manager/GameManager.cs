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
using System.Diagnostics;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public GameObject fog;
    public GameObject fadePanel;
    [HideInInspector] public Image fadeImage;
    public GameObject player;
    [HideInInspector] public FirstPersonController controller;
    public Light flashLight;
    public Transform startPos;
    public GameObject enemy;
    public GameObject ghost;
    public GameObject endingEnemy;
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
    public GameObject endingPanel;
    public AudioSource walk;
    public Text dayText;
    public Transform badendingPos;
    public Transform goodEndingPos;
    public GameObject blood;
    public GameObject endingPlayer;
    public GameObject sacredSword;
    public Transform enemyStartPos;
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
    [HideInInspector] public bool isSafe;
    public float playerDeathStack = 1;
    
    private void Start()
    {
        walk = player.GetComponent<AudioSource>();
        ObjectInit(drawers, drawerChilds);
        ObjectInit(chests, chestChilds);
    }

    public void Restart()
    {
        playerDeathStack += 1;
        EnemyInit();
        StartCoroutine(GetAtk());
    }

    private IEnumerator GetAtk()
    {
        walk.enabled = false;
        fadePanel.SetActive(true);
        dayText.text = "Day " + playerDeathStack.ToString();
        dayText.gameObject.SetActive(true);
        fadeImage.DOFade(0, 4);
        dayText.DOFade(0, 4);
        yield return new WaitForSeconds(4f);
        controller.enabled = true;
        DOTween.Kill(fadeImage);
        DOTween.Kill(dayText);
        fadePanel.SetActive(false);
        dayText.gameObject.SetActive(false);
        fadeImage.color = new Color(0, 0, 0, 1);
        dayText.color = new Color(1, 1, 1, 1);
        walk.enabled = true;
    }

    private void ObjectInit(GameObject g, Transform[] t)
    {
        for (int i = 0; i < g.transform.childCount; i++)
        {
            t[i] = g.transform.GetChild(i);
        }
    }

    private void EnemyInit()
    {
        UnityEngine.Debug.Log("EnemyInit");
        ghost.transform.position = enemyStartPos.position;
    }
}
