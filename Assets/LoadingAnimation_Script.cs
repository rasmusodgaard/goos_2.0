using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class LoadingAnimation_Script : MonoBehaviour
{
    public Ease ease;
    public float speed = 5;
    public string textFinal = "Loading";

    private int numberOfEases;
    private TextMeshProUGUI text;

    private void Start()
    {
        print("DEbug: " +  (int)Ease.INTERNAL_Custom);
        //print(""+System.Runtime.InteropServices.FrameworkDescription);
        numberOfEases = Ease.GetNames(typeof(Ease)).Length;
        text = GetComponent<TextMeshProUGUI>();

        SetNewLoadingAnimation();
    }

    private void SetNewLoadingAnimation()
    {
        text.text = "";
        text.DOText(textFinal ,speed)
                    .SetEase(SetRandomEaseFunction())
                    .SetLoops(2,LoopType.Yoyo)
                    .OnComplete(()=>SetNewLoadingAnimation());
    }

    private Ease SetRandomEaseFunction()
    {
        Ease output;
        int rand = Random.Range(1,numberOfEases-2);
        output = (Ease)rand;
        print("New ease is: " + output);
        return output; 
    }


}
