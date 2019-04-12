using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timer = 0;
    public Collider[] hitColliders;

    void Start()
    {
    }

    void Update()
    {
        if(timer >= 1){
            hitColliders = Physics.OverlapSphere(transform.position, 10);
            for (int i = 0; i < hitColliders.Length; i++){
                if(hitColliders[i].tag == "Icon"){
                    hitColliders[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
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
