using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingTorque : MonoBehaviour
{

    public Vector3 delta;
    private Vector3 lastPos;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        delta = Input.mousePosition - lastPos;

        delta.x = delta.x / Screen.width;
        delta.y = delta.y / Screen.height;

        rb.AddTorque(-delta.x * 2000, ForceMode2D.Force);
        //rb.AddTorque(-delta.y * 2000, ForceMode2D.Force);


        lastPos = Input.mousePosition;
    }
}
