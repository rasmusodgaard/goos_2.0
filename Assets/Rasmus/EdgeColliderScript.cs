using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class EdgeColliderScript : MonoBehaviour
{

    EdgeCollider2D collider;

    void Start()
    {
        collider = GetComponent<EdgeCollider2D>();
        collider.points = new Vector2[] {   new Vector2(-0.5f   ,  0.5f), 
                                            new Vector2( 0.5f   ,  0.5f), 
                                            new Vector2( 0.5f   , -0.5f), 
                                            new Vector2(-0.5f   , -0.5f), 
                                            new Vector2(-0.5f   ,  0.5f) };
    }

    void Update()
    {
        
    }
}
