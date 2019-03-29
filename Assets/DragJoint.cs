using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragJoint : MonoBehaviour
{
    public GameObject joint;
    private  Vector3 mpos;
    private Vector3 pos;
    private Rigidbody rb;

    public Vector3 delta = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;

    void Start()
    {
        pos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        joint.transform.position = new Vector3(mpos.x, mpos.y, 0);

        if (Input.GetMouseButtonUp(0) && gameObject.GetComponent<HingeJoint>() != null)
        {
            AddReleaseForce(delta/10);
            BreakHingeJoint();
        }

        GetMouseVelocity();

    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            MakeHingeJoint();
        }
    }

    void MakeHingeJoint(){
        HingeJoint hj = gameObject.AddComponent<HingeJoint>() as HingeJoint;
        gameObject.GetComponent<HingeJoint>().connectedBody = joint.GetComponent<Rigidbody>();
    }

    void BreakHingeJoint(){
        if(gameObject.GetComponent<HingeJoint>() != null){
            gameObject.GetComponent<HingeJoint>().breakForce = 0;
            gameObject.GetComponent<HingeJoint>().breakTorque = 0;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.0000001f, 0));
        }
    }

    void AddReleaseForce(Vector3 _delta){
        rb.AddForce(_delta, ForceMode.Impulse);
    }

    void GetMouseVelocity(){
        delta = Input.mousePosition - lastPos;
        lastPos = Input.mousePosition;
    }
}

