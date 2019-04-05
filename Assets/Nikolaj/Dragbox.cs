using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragbox : MonoBehaviour
{

    public float spring = 50.0f;
    public float damper = 5.0f;
    public float drag = 10.0f;
    public float angularDrag = 5.0f;
    public float distance = 0.2f;
    public bool attachToCenterOfMass;
    public Camera mainCamera; //Nødvændigt?

    private SpringJoint springJoint;



    void Update()
    {
        if (Input.GetMouseButton(0))
        {



            // mainCamera = FindCamera;

            RaycastHit hit;
            if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                return;
            }

            if (!hit.rigidbody || hit.rigidbody.isKinematic)
            {
                return;
            }

            if (!springJoint)
            {
                GameObject go = new GameObject("Rigidbody dragger");
                Rigidbody body = go.AddComponent<Rigidbody>();
                springJoint = go.AddComponent<SpringJoint>();
                body.isKinematic = true;
                print("adder springjoint");
            }

            springJoint.transform.position = hit.point;
            if (attachToCenterOfMass)
            {
                Vector2 anchor = transform.TransformDirection(hit.rigidbody.centerOfMass) + hit.rigidbody.transform.position;
                anchor = springJoint.transform.InverseTransformPoint(anchor);
                springJoint.anchor = anchor;
            }
            else
            {
                springJoint.anchor = Vector2.zero;
            }


            springJoint.damper = damper;
            springJoint.maxDistance = distance;
            springJoint.spring = spring;
            springJoint.connectedBody = hit.rigidbody;

            StartCoroutine("DragTheBox", hit.distance);
        }
    }

    private IEnumerator DragTheBox(float distance)
    {

        float oldDrag = springJoint.connectedBody.drag;
        float oldAngularDrag = springJoint.connectedBody.angularDrag;
        springJoint.connectedBody.drag = drag;
        springJoint.connectedBody.angularDrag = angularDrag;
        //mainCamera = FindCamera();

        while (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            springJoint.transform.position = ray.GetPoint(distance);
            yield return distance;
        }

        if (springJoint.connectedBody)
        {
            springJoint.connectedBody.drag = oldDrag;
            springJoint.connectedBody.angularDrag = oldAngularDrag;
            springJoint.connectedBody = null;
        }


    }
    

    

}
