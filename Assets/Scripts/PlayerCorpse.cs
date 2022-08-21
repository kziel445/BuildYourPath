using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorpse : MonoBehaviour
{
    public GameObject pfBody;
    public Transform bodyParent;

    void Start()
    {
        PlayerState.GetInstance().PreDie += Body_OnDie;
    }

    public void Body_OnDie(object sender, EventArgs e)
    {
        Instantiate(pfBody, GetComponent<Transform>().position, Quaternion.identity, bodyParent);
    }
}
