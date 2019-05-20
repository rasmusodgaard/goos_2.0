using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClassCounter : MonoBehaviour
{

    public float loadingScore;
    public LoadingBar LB;
    void Start()
    {
        LB = FindObjectOfType<LoadingBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            loadingScore += 0.2f;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sand")
        {
            loadingScore += 0.002f;
            LB.Grow();

        }
    }


        

}
