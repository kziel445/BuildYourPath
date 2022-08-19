using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerState.GetInstance().OutSideSafeZone = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerState.GetInstance().OutSideSafeZone = true;
    }
}
