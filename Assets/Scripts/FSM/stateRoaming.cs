using ItemSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using InputSystem;
public class stateRoaming : State<MonsterFSM>
{
    private Animator animator;
    private AudioSource audioSource;
    private CharacterController characterController; 
    private NavMeshAgent agent;
    private PlayerRaycast playerRayCast;
    private MonsterFSM monsterFSM;
    
    protected int hashMove = Animator.StringToHash("Move");
    protected int hashAttack = Animator.StringToHash("Atk"); 
    protected int hashTarget = Animator.StringToHash("Target");
    protected int hashMoveSpeed = Animator.StringToHash("MoveSpd");
    
    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        audioSource = stateMachineClass.GetComponent<AudioSource>();
        characterController = stateMachineClass.GetComponent<CharacterController>(); 
        agent = stateMachineClass.GetComponent<UnityEngine.AI.NavMeshAgent>();

        monsterFSM = stateMachineClass as MonsterFSM;
    }
    public override void OnStart()
    {
        audioSource.Play();
        if (stateMachineClass.posTarget == null)
        {
            stateMachineClass.SearchNextTargetPosition();
        }
        if (stateMachineClass.posTarget != null)
        {
            Vector3 destination = stateMachineClass.posTarget.position;
            agent?.SetDestination(destination);
            animator?.SetBool(hashMove, true);
        } 

    }
    public override void OnUpdate(float deltaTime)
    {
        if (InputSystems.Instance.isPause == true)
        {
            audioSource.volume = 0f;
        }
        else if(InputSystems.Instance.isPause == false && Mathf.Abs(GameManager.Instance.player.transform.position.y - GameManager.Instance.ghost.transform.position.y) <= 6)
        {
            audioSource.volume = 1f;
        }
        else if (Mathf.Abs(GameManager.Instance.player.transform.position.y - GameManager.Instance.ghost.transform.position.y) > 6)
        {
            audioSource.volume = 0f;
        }
        if(Mathf.Abs(GameManager.Instance.player.transform.position.y - GameManager.Instance.ghost.transform.position.y) <= 4)
        {
            Transform target = stateMachineClass.SearchMonster();
            if (target && GameManager.Instance.hiding == false)
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
            else
            {
                if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance + 0.01f))
                {
                    stateMachineClass.SearchNextTargetPosition();
                    stateMachine.ChangeState<stateIdle>();
                }
                else
                {
                    characterController.Move(agent.velocity * deltaTime);
                    animator.SetFloat(hashMoveSpeed, agent.velocity.magnitude / agent.speed, 0.1f, deltaTime);
                }
            }
        }
        else
        {
            if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance + 0.01f))
            {
                stateMachineClass.SearchNextTargetPosition();
                stateMachine.ChangeState<stateIdle>();
            }
            else
            {
                characterController.Move(agent.velocity * deltaTime);
                animator.SetFloat(hashMoveSpeed, agent.velocity.magnitude / agent.speed, 0.1f, deltaTime);
            }
        }
    }
    public override void OnEnd() { 
        agent.stoppingDistance = stateMachineClass.atkRange;
        agent.ResetPath();
    }
    private void SearchNextTargetPosition() {
        Transform posTarget = monsterFSM.SearchNextTargetPosition();
        if (posTarget != null) agent?.SetDestination(posTarget.position);
    }

}

