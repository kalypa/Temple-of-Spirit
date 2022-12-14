using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI;

public class stateMove : State<MonsterFSM>
{
    private Animator animator;
    private AudioSource audioSource;
    private CharacterController characterController; 
    private NavMeshAgent agent;
     
    private int hashMove = Animator.StringToHash("Run");
    private int hashMoveSpeed = Animator.StringToHash("MoveSpd");
     
    public override void OnAwake()
    { 
        animator = stateMachineClass.GetComponent<Animator>();
        characterController = stateMachineClass.GetComponent<CharacterController>();
        audioSource = stateMachineClass.GetComponent<AudioSource>();
        agent = stateMachineClass.GetComponent<NavMeshAgent>();
    }
    
    public override void OnStart()
    {
        audioSource.Stop();
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.escapeMusic;
        GameManager.Instance.backgroundmusic.Play();
        agent?.SetDestination(stateMachineClass.target.position);
        animator?.SetBool(hashMove, true);
        agent.speed = 5;
    }
     
    public override void OnUpdate(float deltaTime)
    {

        Transform target = stateMachineClass.SearchMonster();
        if (target !=  null && !stateMachineClass.getFlagAtk && GameManager.Instance.hiding == false)
        { 
            agent.SetDestination(stateMachineClass.target.position);
             
            if (agent.remainingDistance > agent.stoppingDistance)
            { 
                characterController.Move(agent.velocity * Time.deltaTime); 
                animator.SetFloat(hashMoveSpeed, agent.velocity.magnitude / agent.speed, 0.1f, Time.deltaTime);
                return;
            }
        }
        else if(GameManager.Instance.hiding == true)
        {
            stateMachine.ChangeState<stateIdle>();
        }
        else
        {
            stateMachine.ChangeState<stateIdle>();
        }
    }
     
    public override void OnEnd()
    {
        GameManager.Instance.backgroundmusic.clip = GameManager.Instance.mainMusic;
        GameManager.Instance.backgroundmusic.Play();
        animator?.SetBool(hashMove, false);
        animator?.SetFloat(hashMoveSpeed, 0); 
        agent.ResetPath();
        agent.speed = 1.5f;
    }
}