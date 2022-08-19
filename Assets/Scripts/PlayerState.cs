using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public EventHandler OnDie;

    private void Player_OnDie(object sender, EventArgs e)
    {
        Debug.Log("Die");
        Debug.Log("Teleport");
    }
    
    private void Awake()
    {
        OnDie += Player_OnDie;
    }
}
