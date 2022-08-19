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
    public EventHandler PreDie;

    public bool OutSideSafeZone = true;

    private void Player_OnDie(object sender, EventArgs e)
    {
        Teleport();
    }
    
    private void Awake()
    {
        instance = this;
        OnDie += Player_OnDie;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && OutSideSafeZone)
        {
            InvokeOnDieEvent();
        }
    }
    public void Teleport()
    {
        gameObject.transform.position = checkPoint;
    }    
    public void InvokeOnDieEvent()
    {
        PreDie?.Invoke(this, EventArgs.Empty);
        OnDie?.Invoke(this, EventArgs.Empty);
    }
        
}
