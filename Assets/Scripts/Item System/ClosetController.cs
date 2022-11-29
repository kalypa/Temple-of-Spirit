using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSystem;
using DG.Tweening.Core.Easing;

public class ClosetController : MonoBehaviour
{
    [SerializeField] private Transform hidePos;
    [SerializeField] private Transform getOutPos;
    [SerializeField] private GameObject closetDoor;
    [SerializeField] private GameObject getOutText;
    [SerializeField] private PlayerRaycast playerRaycast;
    private void Update()
    {

        {
            if (GameManager.Instance.isHiding == true)
            {
                playerRaycast.rayhitF = true;
                if (InputSystem.InputSystems.Instance.pickup)
                {
                    getOutText.SetActive(false);
                    GameManager.Instance.isHiding = false;
                    GameManager.Instance.player.transform.position = getOutPos.position;
                    closetDoor.transform.rotation = Quaternion.Euler(-90, -52.06f, -90);
                    GameManager.Instance.controller.enabled = true;
                    playerRaycast.rayhitF = false;
                    InputSystem.InputSystems.Instance.pickup = false;
                }
            }
        }
    }
    public void Hiding()
    {
        if(!GameManager.Instance.isHiding)
        {
            GameManager.Instance.isHiding = true;
            GameManager.Instance.player.transform.position = hidePos.position;
            GameManager.Instance.player.transform.rotation = Quaternion.Euler(0, 0, 0);
            closetDoor.transform.rotation = Quaternion.Euler(-90, 0, 0);
            GameManager.Instance.controller.enabled = false;
            getOutText.SetActive(true);
        }
    }
}
