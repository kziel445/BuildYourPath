using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoone : MonoBehaviour
{
    public GameObject WinText;
    private void Awake()
    {
        WinText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinText.SetActive(true);
        }
    }
}
