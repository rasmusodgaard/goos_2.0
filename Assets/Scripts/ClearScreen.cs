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

    private Camera cam;
    private Renderer renderer, leftRenderer;
    private float screenMaxX, screenMinX;

    private void Start()
    {
        leftCollider = GameObject.FindWithTag("BorderLeft").transform;
        cam = Camera.main;
        renderer = GetComponent<Renderer>();
        leftRenderer = leftCollider.GetComponent<Renderer>();

        screenMinX = cam.ViewportToWorldPoint(Vector3.zero).x;
        screenMaxX = cam.ViewportToWorldPoint(Vector3.right).x;

        changeScene = false;
        soundFX = GameManager.instance.GetComponent<SoundFX>();

        print("Screen min X" + screenMinX);
        transform.position = new Vector3(screenMaxX + renderer.bounds.extents.x, transform.position.y, transform.position.z);
        leftCollider.position = new Vector3(screenMinX - leftRenderer.bounds.extents.x, leftCollider.position.y, leftCollider.position.z);
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
        soundFX.playSound(ref soundFX.screen_clap, 0.6f);
        yield return new WaitForSeconds(particle.main.duration);
        while(transform.position.x > leftCollider.position.x)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
            yield return null;
        }
        GameManager.instance.NextScene();
    }
}
