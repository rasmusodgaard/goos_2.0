using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColliderScript : MonoBehaviour
{
    Transform transform;
    private Vector2 screenSize;


    void Start()
    {

        transform = GetComponent<Transform>();
        screenSize.x = screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        print("xMax: " + screenSize.x + " yMax: " + screenSize.y);
        transform.position = new Vector3(screenSize.x, screenSize.y,0.0f);

        Vector2 start = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 edge = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));


        Debug.DrawLine(new Vector3 (start.x,start.y,0), new Vector3(edge.x, edge.y, 0),Color.green,100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != new Vector3(screenSize.x, screenSize.y, 0.0f)) 
        {
            transform.position = new Vector3(screenSize.x, screenSize.y, 0.0f);
        }
    }
}
