using AdventurePuzzleKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : SingleMonobehaviour<DrawerController>
{
    [Header("Drawer Animation Name")]
    [SerializeField] private string drawerOpenAnimation = "Open";
    [SerializeField] private string drawerCloseAnimation = "Close";

    [Header("Drawer Sounds")]
    [SerializeField] private string drawerOpenSound = "DrawerOpen";
    [SerializeField] private string drawerCloseSound = "DrawerClose";
    [SerializeField] private GameObject drawer = null;
    private Animator anim;
    public enum DrawerState { Close, Open }
    public DrawerState drawerState = DrawerState.Close;
    private void Start()
    {
        anim = drawer.GetComponent<Animator>();
    }

    public void DrawerCheck()
    {
        switch(drawerState)
        {
            case DrawerState.Open:
                StartCoroutine(PlayDrawerOpenAnimation());
                drawerState = DrawerState.Close;
                InputSystem.InputSystems.Instance.drawer = false;
                break;
            case DrawerState.Close:
                StartCoroutine(PlayDrawerOpenAnimation());
                drawerState = DrawerState.Open;
                InputSystem.InputSystems.Instance.drawer = false;
                break;
        }
    }

    public IEnumerator PlayDrawerOpenAnimation()
    {
        Debug.Log("Good");
        anim.Play(drawerOpenAnimation, 0, 0.0f);
        //DrawerOpenSound();
        yield return null;
    }

    public IEnumerator PlayDrawerCloseAnimation()
    {
        anim.Play(drawerCloseAnimation, 0, 0.0f);
        //DrawerCloseSound();
        yield return null;
    }

    public void DrawerOpenSound()
    {
        AKAudioManager.instance.Play(drawerOpenSound);
    }

    public void DrawerCloseSound()
    {
        AKAudioManager.instance.Play(drawerCloseSound);
    }
}
