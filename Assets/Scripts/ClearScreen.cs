using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    public float speed = 2;
    public ParticleSystem particle;

    Transform leftCollider, rightCollider;
    public bool moving = false;
    private bool changeScene;
    private SoundFX soundFX;

    private void Start()
    {
        changeScene = false;
        leftCollider = GameObject.FindWithTag("BorderLeft").transform;
        soundFX = GameManager.instance.GetComponent<SoundFX>();
    }

    void Update()
    {
        if(transform.position.x < leftCollider.position.x && !changeScene)
        {
            print("Changescene");
            changeScene = true;
        }
    }

    public void StartClearScreen()
    {
        moving = true;
        StartCoroutine(ScreenWipe());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!moving)
        {
            StartClearScreen();
        }
    }

    IEnumerator ScreenWipe()
    {
        particle.Play();
        soundFX.playSound(ref soundFX.screen_clap, 0.8f);
        yield return new WaitForSeconds(particle.main.duration);
        while(transform.position.x > leftCollider.position.x)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
            yield return null;
        }
        GameManager.instance.NextScene();
    }
}
