using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{

    private ClearScreen clearScreen;
    private bool changeScene;

    void Start()
    {
        clearScreen = FindObjectOfType<ClearScreen>();
        changeScene = false;
    }

    public void Grow(float loadingScore)
    {
        transform.localScale += new Vector3(loadingScore, 0f, 0f);
    }

}
