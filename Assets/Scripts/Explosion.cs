using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float timer = 0;
    private Collider[] hitColliders;
    public float explosionForce = 25.0f;

    private DestroyWindow button;
    private Vector3 defaultSize;

    public GameObject ExplodeEffect;

    private void Start()
    {
        button = GetComponentInChildren<DestroyWindow>();
        defaultSize = transform.localScale;
    }

    public void Update()
    {
        float resizingScale = (button.xSize - 0.15f) / 350;
        if(button.resizing){
            transform.localScale = new Vector3(transform.localScale.x + resizingScale, transform.localScale.y + resizingScale, 1);
        }
        if(!button.resizing && transform.localScale.x > defaultSize.x){
            transform.localScale = new Vector3(transform.localScale.x - resizingScale, transform.localScale.y - resizingScale, 1);
        }

    }

    public void Explode()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 10);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Icon" || hitColliders[i].tag == "Window")
            {
                Vector3 explodeDirection = (hitColliders[i].transform.position - (transform.position + new Vector3(0, -5))).normalized;
                hitColliders[i].GetComponent<Rigidbody>().AddForce((explodeDirection * explosionForce), ForceMode.Impulse);
            }
        }
        GameObject Effect = (GameObject)Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 2f);
        Destroy(gameObject);
    }
}
//}
