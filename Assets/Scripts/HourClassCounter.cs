using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClassCounter : MonoBehaviour
{
    [HideInInspector]
    public LoadingBar LB;

    public float speed = 2;

    private SoundFX soundFX;


    void Start()
    {
        LB = FindObjectOfType<LoadingBar>();
        soundFX = GameManager.instance.GetComponent<SoundFX>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sand")
        {
            soundFX.playSound(ref soundFX.sand, 1.0f, true);
            LB.Grow(speed);
        }
    }




}
