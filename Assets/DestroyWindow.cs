using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWindow : MonoBehaviour
{
    private float minSize = 0.15f;
    private float maxSize = 3.34f;
    public float xSize;

    public float smoothTime = 0.3f;
    public float velocity = 0f; 

    public bool resizing = false;

    private Transform parent;

    private void Start()
    {
        parent = transform.parent.GetComponent<Transform>();
        xSize = parent.localScale.x;
    }

    void Update()
    {
        if (resizing){
            ResizeUp();
        } else if(!resizing) {
            ResizeDown();
        }

        parent.localScale = new Vector3(xSize, parent.localScale.y, parent.localScale.z);

        if(xSize > maxSize - 0.001){
            transform.parent.parent.GetComponent<Explosion>().Explode();
        }

    }

    void ResizeUp(){
        xSize = Mathf.SmoothDamp(xSize, maxSize, ref velocity, smoothTime);
    }

    void ResizeDown(){
        xSize = Mathf.SmoothDamp(xSize, minSize, ref velocity, smoothTime);
    }
}
