using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using DG.Tweening.Core.Easing;

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
            if (InputSystem.InputSystems.Instance.pickup)
            {
                AudioManager.instance.Play("ClosetOpen");
                getOutText.SetActive(false);
                isHiding = false;
                GameManager.Instance.player.transform.position = getOutPos.transform.position;
                closetDoor.transform.rotation = Quaternion.Euler(-90, 52.06f, -90);
                GameManager.Instance.controller.enabled = true;
                GameManager.Instance.walk.enabled = true;
                playerRaycast.rayhitF = false;
                InputSystem.InputSystems.Instance.pickup = false;
            }
        }
    }
    public void Hiding()
    {
        if(!isHiding)
        {
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
}
