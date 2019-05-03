using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public ClearScreen clearingScreen;
    public GameObject ExplodeEffect;

    // Start is called before the first frame update
    void Start()
    {

        clearingScreen = FindObjectOfType<ClearScreen>();

    }

    // Update is called once per frame
    void Update()
    {

     

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (clearingScreen.moving)
        {
            if (collision.gameObject.CompareTag("BorderLeft"))
            {
                GameObject Effect = (GameObject)Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(Effect, 2f);
            }
           
        }
    }

}
