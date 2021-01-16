using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourClassCounter : MonoBehaviour
{

    public float loadingScore;
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
            soundFX.playSound(ref soundFX.sand, 0.8f, true);
            loadingScore += 0.002f * speed;
            LB.Grow(loadingScore);
        }
    }




}
