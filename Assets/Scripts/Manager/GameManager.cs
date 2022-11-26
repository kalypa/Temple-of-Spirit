using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public GameObject mapPrefab;
    public GameObject fog;
    public Volume volumeObject;
    public GameObject fadePanel;
    public GameObject player;
    [HideInInspector] public FirstPersonController controller;
    public GameObject enemy;
}
