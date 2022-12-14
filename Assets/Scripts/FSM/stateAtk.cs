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
        PanelDown();
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
            EnemySpawn();
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
       
        GameManager.Instance.controller.enabled = false;
        GameManager.Instance.walk.enabled = false;
        GameManager.Instance.playerInput.enabled = false;
        InputSystems.Instance.flash = false;
        InputSystems.Instance.isFlash = false;
        GameManager.Instance.flashLight.enabled = InputSystems.Instance.flash;
        GameManager.Instance.deadCam.gameObject.SetActive(true);
        AtkAnim();
        GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
    }

    private void EnemySpawn()
    {
        GameManager.Instance.ghost.SetActive(false);
        GameManager.Instance.ghost.transform.position = GameManager.Instance.enemyStartPos.position;
        GameManager.Instance.ghost.SetActive(true);
    }
    private void AtkAnim()
    {
        animator?.SetTrigger(atkTriggerHash);
        AudioManager.instance.Play("Scream");
    }

    private void PanelDown()
    {
        SafeController.Instance.SafeUIFalse();
        InputSystems.Instance.isInven = false;
        InputSystems.Instance.isPanel = false;
        OnClickManager.Instance.note1.tag = "InteractiveObject";
        OnClickManager.Instance.note2.tag = "InteractiveObject";
        OnClickManager.Instance.note3.tag = "InteractiveObject";
        OnClickManager.Instance.note4.tag = "InteractiveObject";
        OnClickManager.Instance.note5.tag = "InteractiveObject";
        OnClickManager.Instance.note6.tag = "InteractiveObject";
        OnClickManager.Instance.note7.tag = "InteractiveObject";
        OnClickManager.Instance.note8.tag = "InteractiveObject";
        OnClickManager.Instance.note9.tag = "InteractiveObject";
        OnClickManager.Instance.note10.tag = "InteractiveObject";
        OnClickManager.Instance.notePanel1.SetActive(false);
        OnClickManager.Instance.notePanel2.SetActive(false);
        OnClickManager.Instance.notePanel3.SetActive(false);
        OnClickManager.Instance.notePanel4.SetActive(false);
        OnClickManager.Instance.notePanel5.SetActive(false);
        OnClickManager.Instance.notePanel6.SetActive(false);
        OnClickManager.Instance.notePanel7.SetActive(false);
        OnClickManager.Instance.notePanel8.SetActive(false);
        OnClickManager.Instance.notePanel9.SetActive(false);
        OnClickManager.Instance.notePanel10.SetActive(false);
    }
}
