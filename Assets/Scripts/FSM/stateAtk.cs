using DG.Tweening;
using InputSystem;
using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class stateAtk : State<MonsterFSM>
{
    private Animator animator;
    private PlayerRaycast playerRaycast;
    protected int atkTriggerHash = Animator.StringToHash("Atk");
    protected int atkIndexHash = Animator.StringToHash("AtkIdx");

    public override void OnAwake()
    {
        playerRaycast = stateMachineClass.playerRaycast;
        animator = stateMachineClass.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        GameManager.Instance.isAtk = true;
        if (playerRaycast.closet != null && !playerRaycast.closet.isHiding)
        {
            AtkStart();
        }
        else if (playerRaycast.closet == null)
        {
            AtkStart();
        }
        else
        {
            stateMachine.ChangeState<stateIdle>();
        }
    }
     
    public override void OnUpdate(float deltaTime) 
    {
        if(!GameManager.Instance.isAtk)
        {
            stateMachine.ChangeState<stateIdle>();
        }
    }

    public override void OnEnd()
    {
        if (GameManager.Instance.playerDeathStack < 3)
        {
            GameManager.Instance.deadCam.gameObject.SetActive(false);
            GameManager.Instance.Restart();
        }
        else
        {
            GameManager.Instance.deadCam.gameObject.SetActive(false);
            GameManager.Instance.endingPlayer.SetActive(true);
            EndingController.Instance.SadEnding();
        }
    }
    private void AtkStart()
    {
        GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
        GameManager.Instance.controller.enabled = false;
        InputSystems.Instance.flash = false;
        InputSystems.Instance.isFlash = false;
        GameManager.Instance.flashLight.enabled = InputSystems.Instance.flash;
        GameManager.Instance.deadCam.gameObject.SetActive(true);
        AtkAnim();
    }
    private void AtkAnim()
    {
        animator?.SetTrigger(atkTriggerHash);
        AudioManager.instance.Play("Scream");
    }
}
