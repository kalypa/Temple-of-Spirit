using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
 
public enum BatteryStack
{ 
    Int, Battery, Str
}

[Serializable]  
public class ItemAbility 
{ 
    public BatteryStack batteryStack; 
    public int valStack;
     
    public ItemAbility()
    { 
        getStackVal();
    }
    
    public void getStackVal()
    {
        valStack = 25;
    }
     
    public void addStackVal(ref int v)
    {
        v += valStack;
    } 
} 
