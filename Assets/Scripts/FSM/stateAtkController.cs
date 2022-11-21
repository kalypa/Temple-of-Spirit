using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class stateAtkController : MonoBehaviour
{  
    public delegate void OnStartStateAtkController(); 
    public OnStartStateAtkController stateAtkControllerStartHandler;

    public delegate void OnEndStateAtkController(); 
    public OnEndStateAtkController stateAtkControllerEndHandler;
     
    public bool getFlagStateAtkController
    {
        get; 
        private set;
    }

    private void Start()
    { 
        stateAtkControllerStartHandler
            = new OnStartStateAtkController(stateAtkControllerStart); 
        stateAtkControllerEndHandler
            = new OnEndStateAtkController(stateAtkControllerEnd);
    }
     
    private void stateAtkControllerStart()
    {
    }

    private void stateAtkControllerEnd()
    {
    }
     
    public void EventStateAtkStart()
    { 
        getFlagStateAtkController = true; 
        stateAtkControllerStartHandler();
    }
      
    public void EventStateAtkEnd()
    { 
        getFlagStateAtkController = false; 
        stateAtkControllerEndHandler();
    }
     
    public void OnCheckAttackCollider(int attackIndex)
    {
        Debug.Log("---------------------attackIndex : " + attackIndex);
        GetComponent<IAtkAble>()?.OnExecuteAttack(attackIndex);
    }
}
