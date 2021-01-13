using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChar : MonoBehaviour
{

    private bool dragging = false;
    private float distance;

    void OnMouseDown()
    {

        distance = Vector2.Distance(transform.position, Camera.main.transform.position);
        dragging = true;

    }
    private void OnMouseUp()
    {
        dragging = false;
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector2 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }

        
    }


}
