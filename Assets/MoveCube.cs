using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    public Vector3 scl;
    public MouseWiggle ball;
    private float speed;

    void Start()
    {
        scl = transform.localScale;
        ball = FindObjectOfType<MouseWiggle>();
        speed = scl.x;
    }

    void Update()
    {
        speed = ball.angVel / 1000000;

        if (scl.x > 1) {
            scl.x = 1;
        }
        scl = new Vector3(scl.x + speed, scl.y, scl.z);
        transform.localScale = scl;
    }
}
