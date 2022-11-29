using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{

    protected StateMachine<MonsterFSM> fsmManager;
    public StateMachine<MonsterFSM> FsmManager => fsmManager;
     
    private FieldOfView fov;
    public Transform target => fov?.FirstTarget;

    public Transform[] posTargets;
    public Transform posTarget = null;
    private int posTargetsIdx = 0;
     
    public float atkRange;

    protected virtual void Start()
    {

        fsmManager = new StateMachine<MonsterFSM>(this, new stateRoaming());
        stateIdle stateIdle = new stateIdle();
        stateIdle.flagRoaming = true;
        fsmManager.AddStateList(stateIdle);
        fsmManager.AddStateList(new stateMove());
        fsmManager.AddStateList(new stateAtk());


        fov = GetComponent<FieldOfView>();
    }

    protected virtual void Update()
    {
        fsmManager.Update(Time.deltaTime);  
    }

    public virtual Transform SearchMonster()
    {
        if (!GameManager.Instance.isHiding)
            return target;
        else
            return null;
    }


    public virtual bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }

            float distance = Vector3.Distance(transform.position, target.position); 
            return (distance <= atkRange);
        }
    }
    public Transform SearchNextTargetPosition()
    {
        posTarget = null;
        if (posTargets.Length > 0) {
            posTargetsIdx = Random.Range(0, posTargets.Length);
            posTarget = posTargets[posTargetsIdx];
        }

        posTargetsIdx = Random.Range(0, posTargets.Length);
        
        return posTarget;
    }

}





