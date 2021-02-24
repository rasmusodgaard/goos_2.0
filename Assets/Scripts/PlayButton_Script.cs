using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PlayButton_Script : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image panel;
    private bool clicked = false;

    [Header("Text Hover Options")]
    public float hoverDuration = 1;
    public float hoverOffset = 10;
    public Ease hoverEaseFunction;

    [Header("Play Button Fade Options")]
    public float fadeDuration = 1.5f;
    public Ease fadeEaseFunction;



    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        panel = GetComponentInChildren<Image>();
        HoverText(true);
    }

    private void HoverText(bool nextIsUp)
    {
        int scalar = (nextIsUp) ? 1 : -1;
        text.transform.DOMoveY(text.transform.position.y + hoverOffset * scalar, hoverDuration)
            .SetEase(hoverEaseFunction)
            .SetLoops(2, LoopType.Yoyo)
            .OnComplete(() => HoverText(!nextIsUp));
    }

    private void Update()
    {
        if(Input.anyKeyDown && !clicked)
        {
            FadeOutPlayButton();
        }
    }

    private void FadeOutPlayButton()
    {
        clicked = true;
        Sequence fadeOut = DOTween.Sequence();
        fadeOut.Append(panel.DOFade(0, fadeDuration))
               .Join(text.DOFade(0, fadeDuration)).OnComplete(() => this.gameObject.SetActive(false));
    }
}
