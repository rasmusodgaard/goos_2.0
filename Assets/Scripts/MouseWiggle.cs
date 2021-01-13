using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWiggle : MonoBehaviour
{
    public bool shake;
    Rigidbody2D rb;
    public float torque = 5;
    public float angVel;

    Vector2 oldMouseAxis;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        this.shake = Mathf.Sign(mouseAxis.x) != Mathf.Sign(this.oldMouseAxis.x) || Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y);

        if (shake)
        {
            rb.AddTorque(-torque, ForceMode2D.Force);
        }

        angVel = -rb.angularVelocity;


        this.oldMouseAxis = mouseAxis;
        //if (this.shake) Debug.Log(Time.time);

    }
}
