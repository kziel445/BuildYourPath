using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject GameOverObject;
    Vector3 startPosition = new Vector3(200,100);
    Vector3 endPosition = new Vector3(200,-100);

    private void Awake()
    {
        PlayerState.GetInstance().OnDie += SpawnGameOver;
        startPosition.z = transform.position.z;
        endPosition.z = transform.position.z;
    }
    private void SpawnGameOver(object sender, EventArgs e)
    {
        var go = Instantiate(GameOverObject, startPosition, Quaternion.identity, transform);
        go.GetComponent<GameOver>().endPosition = endPosition;
    }
}
