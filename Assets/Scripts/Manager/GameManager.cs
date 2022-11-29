using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public GameObject fog;
    public GameObject fadePanel;
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
}
