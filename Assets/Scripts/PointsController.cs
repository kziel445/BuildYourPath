using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private static PointsController instance;
    public static PointsController GetInstance()
    {
        return instance;
    }
    public EventHandler GetPoint;
    public TMPro.TextMeshProUGUI text;

    public int points = 0;
    private void Awake()
    {
        instance = this;
        text = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        GetPoint += Player_GetPoint;
    }
    private void Player_GetPoint(object sender, EventArgs e)
    {
        points++;
        UpdatePoints();
    }
    private void UpdatePoints()
    {
        text.text = points.ToString("D4");
    }
}
