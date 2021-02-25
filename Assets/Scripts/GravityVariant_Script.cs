using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityVariant_Script : MonoBehaviour
{
    public float newGravity = 40;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(!rigidbody.useGravity)
        {
            rigidbody.AddForce(Vector3.down * rigidbody.mass * newGravity);
        }
    }
}
