using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClassCounter : MonoBehaviour
{

    public float loadingScore;
    public LoadingBar LB;
    public float speed = 2;


    void Start()
    {
        LB = FindObjectOfType<LoadingBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sand")
        {
            loadingScore += 0.002f * speed;
            LB.Grow();
        }
    }




}
