using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class LoadingAnimation_Script : MonoBehaviour
{
    TextMeshProUGUI text;
    Public Ease ease;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.DOText("Loading...",5).SetEase(ease).SetLoops(-1);
    }


}
