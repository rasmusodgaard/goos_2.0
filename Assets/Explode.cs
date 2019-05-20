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


    private void OnCollisionEnter(Collision collision)
    {
        if (clearingScreen.moving)
        {
            print("bevæg");
            if (collision.gameObject.CompareTag("BorderLeft"))
            {
                print("dø");
                GameObject Effect = (GameObject)Instantiate(ExplodeEffect, transform.position, Quaternion.identity);
                GameManager.instance.GetComponent<SoundFX>().playExplosion();
                Destroy(this.gameObject);
                Destroy(Effect, 2f);
            }
           
        }
    }

}
