using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using DG.Tweening.Core.Easing;
using InputSystem;
using UnityEngine.Windows;

public class ClosetController : MonoBehaviour
{
    [SerializeField] private GameObject hidePos;
    [SerializeField] private GameObject getOutPos;
    [SerializeField] private GameObject closetDoor;
    [SerializeField] private GameObject getOutText;
    [SerializeField] private PlayerRaycast playerRaycast;
    [HideInInspector] public bool isHiding;
    private void Update()
    {
        if (isHiding == true)
        {
            playerRaycast.rayhitF = true;
            if (InputSystems.Instance.pickup)
            {
                AudioManager.instance.Play("ClosetOpen");
                getOutText.SetActive(false);
                isHiding = false;
                closetDoor.transform.rotation = Quaternion.Euler(-90, 52.06f, -90);
                GameManager.Instance.player.transform.position = getOutPos.transform.position;
                playerRaycast.rayhitF = false;
                InputSystems.Instance.pickup = false;
                GameManager.Instance.controller.enabled = true;
                GameManager.Instance.walk.enabled = true;
                GameManager.Instance.hiding = false;
            }
        }
        Inven();
        Flash();
        Pause();
    }
    public void Hiding()
    {
        if(!isHiding && GameManager.Instance.isAtk == false)
        {
            GameManager.Instance.hiding = true;
            AudioManager.instance.Play("ClosetClose");
            isHiding = true;
            GameManager.Instance.player.transform.position = hidePos.transform.position;
            GameManager.Instance.player.transform.rotation = Quaternion.identity;
            closetDoor.transform.rotation = Quaternion.Euler(-90, 0, 0);
            GameManager.Instance.controller.enabled = false;
            GameManager.Instance.walk.enabled = false;
            getOutText.SetActive(true);
        }
    }
    private void Inven()
    {
        GameManager.Instance.inventory.SetActive(InputSystems.Instance.inven);
    }
    private void Flash()
    {
        GameManager.Instance.flashLight.enabled = InputSystems.Instance.flash;
        OnClickManager.Instance.batteryUI.SetActive(GameManager.Instance.hasFlashLight);
        if (InputSystems.Instance.flash)
        {
            GameManager.Instance.battery.value -= 0.01f * Time.deltaTime;
        }
        if (GameManager.Instance.battery.value <= 0)
        {
            InputSystems.Instance.flash = false;
        }
    }
    private void Pause()
    {
        GameManager.Instance.pausePanel.SetActive(InputSystems.Instance.pause);
        if (InputSystems.Instance.pause == true)
        {
            GameManager.Instance.walk.volume = 0f;
            Time.timeScale = 0;
        }
        else
        {
            GameManager.Instance.walk.volume = 1f;
            Time.timeScale = 1;
        }
    }
}
