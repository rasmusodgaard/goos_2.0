using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandRespawner_Script : MonoBehaviour
{
    public Transform respawnPoint_1, respawnPoint_2;



    private void OnTriggerExit(Collider other)
    {
        print(other.tag + " exited collider.");
        if(other.tag == "Sand" && gameObject.name == "Hourglass")
        {
            print("Pre-position: " + other.transform.position);
            other.attachedRigidbody.velocity = Vector3.zero;
            other.transform.position = GetLowestTransformXY(other.transform.position.z);
            print("Post-position: " + other.transform.position);
        }
    }

    private Vector3 GetLowestTransformXY(float z)
    {
        print("Get Lowest transform");
        if(respawnPoint_1.position.y < respawnPoint_2.position.y)
            return new Vector3(respawnPoint_1.position.x, respawnPoint_1.position.y, z);

        else
            return new Vector3(respawnPoint_2.position.x, respawnPoint_2.position.y, z);
    }
}
