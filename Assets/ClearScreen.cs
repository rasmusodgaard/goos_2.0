using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{

    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moving = true;
            print("SPace pressed");
        }

        if (moving)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);

        }
    }

 

}
