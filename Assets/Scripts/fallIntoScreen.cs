using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallIntoScreen : MonoBehaviour
{

    public BoxCollider topCol;
    BoxCollider col;

    bool outsideScreen;
    void Start()
    {
        outsideScreen = true;
        col = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (outsideScreen)
        {
            if (col.bounds.max.y < topCol.bounds.min.y)
            {
                outsideScreen = false;
                transform.position = new Vector3(transform.position.x, transform.position.y,0);
            }
        }
    }
}
