﻿using UnityEngine;

public class RigidbodyCollisionLimiter : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector3 position, velocity, angularVelocity;
    bool isColliding;

    public string targetTag;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(!isColliding)
        {
            position = rigidbody.position;
            velocity = rigidbody.velocity;
            angularVelocity = rigidbody.angularVelocity;
        }
    }

    void LateUpdate()
    {
        if(isColliding)
        {
            rigidbody.position = position;
            rigidbody.velocity = velocity;
            rigidbody.angularVelocity = angularVelocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
            isColliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Player")
            isColliding = false;
    }
}