﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    int clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                Debug.Log(gameObject.name + " DOUBLE CLICKED");

            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        }
    }
}