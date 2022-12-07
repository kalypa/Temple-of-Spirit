using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    [Header("Drawer Animation Name")]
    [SerializeField] private string drawerOpenAnimation;
    [SerializeField] private string drawerCloseAnimation;

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
                StartCoroutine(PlayDrawerCloseAnimation());
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
        gameObject.tag = "Untagged";
        anim.Play(drawerOpenAnimation, 0, 0.0f);
        DrawerOpenSound();
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Drawer";
    }

    public IEnumerator PlayDrawerCloseAnimation()
    {
        gameObject.tag = "Untagged";
        anim.Play(drawerCloseAnimation, 0, 0.0f);
        DrawerCloseSound();
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Drawer";
    }

    public void DrawerOpenSound()
    {
        Debug.Log("Open");
        AudioManager.instance.Play(drawerOpenSound);
    }

    public void DrawerCloseSound()
    {
        Debug.Log("Close");
        AudioManager.instance.Play(drawerCloseSound);
    }
}
