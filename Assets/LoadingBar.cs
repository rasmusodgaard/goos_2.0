using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{

    public HourClassCounter HGC;

    private bool changeScene;

    void Start()
    {
        HGC = FindObjectOfType<HourClassCounter>();
        changeScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 18 && !changeScene)
        {
            GameManager.instance.NextScene();
            changeScene = false;
        }
    }

    public void Grow()
    {

        transform.localScale += new Vector3(HGC.loadingScore, 0f, 0f);


    }

}
