using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;
    public static PlayerState GetInstance()
    {
        return instance;
    }

    public Vector3 checkPoint;

    public EventHandler OnDie;

    private void Player_OnDie(object sender, EventArgs e)
    {
        Debug.Log("Die");
        Teleport();
    }
    
    private void Awake()
    {
        instance = this;
        OnDie += Player_OnDie;
    }
    public void Teleport()
    {
        gameObject.transform.position = checkPoint;
    }    
    public void InvokeOnDieEvent()
    {
        OnDie?.Invoke(this, EventArgs.Empty);
    }
        
}
