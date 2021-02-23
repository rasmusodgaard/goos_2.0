using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;


public class PlayButton_Script : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float duration = 1;
    public float offset = 10;
    public Ease easeFunction;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        HoverText(true);
    }

    private void HoverText(bool nextIsUp)
    {
        int scalar = (nextIsUp) ? 1 : -1;
        text.transform.DOMoveY(text.transform.position.y + offset * scalar, duration)
            .SetEase(easeFunction)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => HoverText(!nextIsUp));


    }

}
