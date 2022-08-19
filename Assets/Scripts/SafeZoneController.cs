using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerState.GetInstance().checkPoint = transform.GetChild(1).position;
            PlayerState.GetInstance().OutSideSafeZone = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") PlayerState.GetInstance().OutSideSafeZone = true;
    }
}
