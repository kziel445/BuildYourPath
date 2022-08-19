using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float speed = 40;
    public Vector3 endPosition;
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        if(transform.position == endPosition)
        {
            Destroy(gameObject);
        }
    }
}
