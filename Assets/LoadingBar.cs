using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{

    public HourClassCounter HGC;

    void Start()
    {
        HGC = FindObjectOfType<HourClassCounter>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Grow()
    {

        transform.localScale += new Vector3(HGC.loadingScore, 0f, 0f);


    }

}
