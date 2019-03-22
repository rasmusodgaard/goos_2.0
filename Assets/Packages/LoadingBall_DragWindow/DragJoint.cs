using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragJoint : MonoBehaviour
{

    public GameObject j;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        j.transform.position = new Vector3(mpos.x, mpos.y, 0);

        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<HingeJoint>().breakForce = 0;
            gameObject.GetComponent<HingeJoint>().breakTorque = 0;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0000001f, 0, 0));
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            HingeJoint hj = gameObject.AddComponent<HingeJoint>() as HingeJoint;
            gameObject.GetComponent<HingeJoint>().connectedBody = j.GetComponent<Rigidbody>();
        }
    }
}
