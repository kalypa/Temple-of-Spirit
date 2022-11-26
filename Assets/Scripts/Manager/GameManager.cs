using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class GameManager : SingleMonobehaviour<GameManager>
{
    public GameObject mapPrefab;
    public GameObject fog;
    public GameObject fadePanel;
    public GameObject player;
    [HideInInspector] public FirstPersonController controller;
    public GameObject enemy;
}
