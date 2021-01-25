using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class LoadingAnimation_Script : MonoBehaviour
{
    public Ease ease;
    public float speed = 5;
    public string textFinal = "Loading";
    public string loginText = "Please Log In To GoOS";
    public bool looping = true;

    private int numberOfEases;
    private TextMeshProUGUI text;

    private void Start()
    {
        //PrintSceneNames();
        //print(""+System.Runtime.InteropServices.FrameworkDescription);
        numberOfEases = Ease.GetNames(typeof(Ease)).Length;
        text = GetComponent<TextMeshProUGUI>();

        if(looping)
        {
            SetNewLoadingAnimation();
        }
        else
        {
            PlayAnimationOnce();
        }
    }

    private void PlayAnimationOnce()
    {
        text.text = "";
        text.DOText(loginText, speed / 2);
    }

    private void PrintSceneNames()
    {
        print("Scenes in the build index:");
        for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            print(SceneManager.GetSceneByBuildIndex(i).name);
        }
    }

    private void SetNewLoadingAnimation()
    {
        text.text = "";
        text.DOText(textFinal, speed)
                    .SetEase(SetRandomEaseFunction())
                    .SetLoops(2, LoopType.Yoyo)
                    .OnComplete(() => SetNewLoadingAnimation());
    }

    private Ease SetRandomEaseFunction()
    {
        Ease output;
        int rand = UnityEngine.Random.Range(1, numberOfEases - 2);
        output = (Ease)rand;
        return output;
    }


}
