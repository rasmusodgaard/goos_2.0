using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHinge : MonoBehaviour
{
    Transform t;
    Transform objectHit;
    HingeJoint2D joint;

    void Start()
    {
        t = transform;
        //joint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        t.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

             if (hit.collider != null)
             {
                 print(hit.transform.name);
                 objectHit = hit.transform;
                 joint = objectHit.gameObject.AddComponent<HingeJoint2D>();
                 joint.connectedBody = objectHit.GetComponent<Rigidbody2D>();
                 joint.autoConfigureConnectedAnchor = true;
                 print(joint.connectedAnchor.x + " " + joint.connectedAnchor.y);
             }
            
             print(joint.connectedAnchor.x + " " + joint.connectedAnchor.y);

        }

        if (Input.GetMouseButton(0))
        {
            //joint.anchor = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //joint.connectedAnchor = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(joint);
        }



    }


}
