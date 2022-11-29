using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetController : MonoBehaviour
{
    [SerializeField] private Transform hidePos;
    [SerializeField] private GameObject closetDoor;
    public void Hiding()
    {
        if(!GameManager.Instance.isHiding)
        {
            GameManager.Instance.isHiding = true;
            GameManager.Instance.player.transform.position = hidePos.position;
            GameManager.Instance.player.transform.rotation = hidePos.rotation;
            GameManager.Instance.controller.enabled = false;
            closetDoor.transform.rotation = Quaternion.Euler(-90, 0, -90);
        }
        else
        {
            GameManager.Instance.isHiding = false;
            closetDoor.transform.rotation = Quaternion.Euler(-90, -52.06f, -90);
            GameManager.Instance.controller.enabled = true;
        }
    }
}
