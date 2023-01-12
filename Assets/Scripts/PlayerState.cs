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

    AudioSource audio;

    public EventHandler OnRespawn;
    public EventHandler OnDie;
    public EventHandler PreDie;

    public bool OutSideSafeZone = true;

    private void Player_OnDie(object sender, EventArgs e)
    {
        StartCoroutine(CastTeleportation(1));
        ChangeVisibility(false);
    }
    public void Player_OnRespawn(object sender, EventArgs e)
    {
        ChangeVisibility(true);
    }
    private void Awake()
    {
        instance = this;
        OnDie += Player_OnDie;
        OnRespawn += Player_OnRespawn;
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && OutSideSafeZone)
        {
            InvokeOnDieEvent();
        }
    }
    IEnumerator CastTeleportation(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Respawn();
    }
    public void ChangeVisibility(bool visible)
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = visible;
        gameObject.GetComponent<Collider2D>().enabled = visible;
        
        gameObject.GetComponent<Rigidbody2D>().bodyType = 
            visible ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;

    }
    public void Teleport()
    {
        gameObject.transform.position = checkPoint;
    }    
    public void Respawn()
    {
        Teleport();
        OnRespawn?.Invoke(this, EventArgs.Empty);
    }
    public void InvokeOnDieEvent()
    {
        audio.Play();
        PreDie?.Invoke(this, EventArgs.Empty);
        OnDie?.Invoke(this, EventArgs.Empty);
    }
}
