using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class stateIdle : State<MonsterFSM>
{
    public bool flagRoaming = false;
    private float minRoamingIdleTime = 0f;
    private float maxRoamingIdleTime = 3.0f;
    private float roamingIdleTime = 0f;



    private Animator animator;
    private CharacterController characterController;

    protected int hashMove = Animator.StringToHash("Move");
    protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        characterController = stateMachineClass.GetComponent<CharacterController>();
    }

    public override void OnStart()
    {
        animator?.SetBool(hashMove, false);
        animator.SetFloat(hashMoveSpd, 0);
        characterController?.Move(Vector3.zero);

        if (flagRoaming)
        {
            roamingIdleTime = Random.Range(minRoamingIdleTime, maxRoamingIdleTime);
        }
    }
      
    public override void OnUpdate(float deltaTime)
    {
        if (stateMachineClass.target)
        {
            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<stateAtk>();
            }
            else
            {
                stateMachine.ChangeState<stateMove>();
            }
        }
        else if (flagRoaming && stateMachine.getStateDurationTime > roamingIdleTime)
        {
            stateMachine.ChangeState<stateRoaming>();
        }
    }
} 