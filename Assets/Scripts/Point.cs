using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PointsController.GetInstance().GetPoint?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
