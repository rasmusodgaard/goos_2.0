using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderDotPosition : MonoBehaviour
{
    public Transform sliderDot;
    public Transform frame;

    void Start()
    {
        sliderDot = gameObject.transform.GetChild(0).transform;
        frame = gameObject.transform.GetChild(1).transform;
    }

    void Update()
    {
        sliderDot.position = frame.position;
    }
}
