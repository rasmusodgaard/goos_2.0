using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public Collider[] hitColliders;

    void Start()
    {
    }

    void Update()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 10);
    }
}
