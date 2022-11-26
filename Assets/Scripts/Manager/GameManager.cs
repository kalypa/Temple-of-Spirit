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
    public Volume volume;
    public GameObject fadePanel;
    public GameObject player;
    [HideInInspector] public FirstPersonController controller;
    public GameObject enemy;
    public DepthOfField depthOfField;
    public Vignette vignette;
    private void Start()
    {
        if (volume.profile.TryGet<Vignette>(out Vignette v))
        {
            vignette = v;
        }
    }
}
