using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float timer = 0;
    private Collider[] hitColliders;
    public float explosionForce = 25.0f;

    void Update()
    {
        if(timer >= 1){
            hitColliders = Physics.OverlapSphere(transform.position, 10);
            for (int i = 0; i < hitColliders.Length; i++){
                if(hitColliders[i].tag == "Icon" || hitColliders[i].tag == "Window") {
                    Vector3 explodeDirection = (hitColliders[i].transform.position - (transform.position+new Vector3(0,-5))).normalized;
                    hitColliders[i].GetComponent<Rigidbody>().AddForce((explodeDirection * explosionForce), ForceMode.Impulse);
                }
            }

            Destroy(gameObject);
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0)){
            timer += Time.deltaTime;
        }
    }
}
