using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTest : MonoBehaviour
{

    public float distance = 0.2f;
    public float dampingRatio = 1;
    public float frequency = 1.8f;
    public float linearDrag = 1.0f;
    public float angularDrag = 5.0f;
    private SpringJoint2D springJoint;


    // Start is called before the first frame update
    void Start()
    {
        if (!springJoint)
        {
            GameObject go = new GameObject("Rigidbody 2D Dragger");
            Rigidbody2D body = go.AddComponent<Rigidbody2D>();

            springJoint = go.AddComponent<SpringJoint2D>();
            body.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Camera mainCamera = FindCamera();

        int mask = (1 << 8);
        RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, mask);

        if (hit.rigidbody != null && hit.rigidbody.isKinematic == true)
        {
            return;
        }

        if (hit.rigidbody != null && hit.rigidbody.isKinematic == false)
        {
            springJoint.transform.position = hit.point;

            springJoint.dampingRatio = dampingRatio;
            springJoint.frequency = frequency;
            springJoint.distance = distance;

            springJoint.connectedBody = hit.rigidbody;

            StartCoroutine("DragObject", hit.fraction);
        }
    }

    IEnumerator DragObject (float distance)
    {
        float oldDrag = springJoint.connectedBody.drag;
        float oldAngularDrag = springJoint.connectedBody.angularDrag;

        springJoint.connectedBody.drag = linearDrag;
        springJoint.connectedBody.angularDrag = angularDrag;

        Camera mainCamera = FindCamera();

        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(distance);
            yield return null;
        }

        if (springJoint.connectedBody)
        {
            springJoint.connectedBody.drag = oldDrag;
            springJoint.connectedBody.angularDrag = oldAngularDrag;
            springJoint.connectedBody = null;
        }


    }

    Camera FindCamera()
    {

        if (GetComponent<Camera>())
            return GetComponent<Camera>();
        else
            return Camera.main;
    }

}
