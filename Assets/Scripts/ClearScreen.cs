using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreen : MonoBehaviour
{
    public float speed = 2;

    Transform leftCollider, rightCollider;
    public bool moving = false;
    private bool changeScene;

    private void Start()
    {
        changeScene = false;
        leftCollider = GameObject.FindWithTag("BorderLeft").transform;
        rightCollider = GameObject.FindWithTag("BorderRight").transform;
    }

    void Update()
    {
        if (moving && !changeScene)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (rightCollider.position.x < leftCollider.position.x && !changeScene)
        {
            print("Changescene");
            changeScene = true;
            GameManager.instance.NextScene();
        }
    }

    public void StartClearScreen()
    {
        moving = true;
    }
}
