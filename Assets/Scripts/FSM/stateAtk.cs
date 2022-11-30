using DG.Tweening;
using InputSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
public class stateAtk : State<MonsterFSM>
{

    private Animator animator; 
    
    protected int atkTriggerHash = Animator.StringToHash("Atk");
    protected int atkIndexHash = Animator.StringToHash("AtkIdx");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
    }

    public override void OnStart()
    {
        if(!ClosetController.Instance.isHiding)
        {
            animator?.SetTrigger(atkTriggerHash);
            InputSystems.Instance.flash = false;
            InputSystems.Instance.isFlash = false;
            GameManager.Instance.controller.enabled = false;
            GameManager.Instance.player.transform.position = GameManager.Instance.startPos.position;
            GameManager.Instance.deadCam.gameObject.SetActive(true);
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
        if(!ClosetController.Instance.isHiding)
        {
            GameManager.Instance.deadCam.gameObject.SetActive(false);
            GameManager.Instance.Restart();
        }
    }
}
