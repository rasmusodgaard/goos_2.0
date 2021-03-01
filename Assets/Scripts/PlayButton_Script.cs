using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayButton_Script : MonoBehaviour
{
    private TextMeshProUGUI text;
    private bool clicked = false;
    private GraphicRaycaster raycaster;


    public BootUp_Script bootUp_Script;

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
        raycaster = GetComponent<GraphicRaycaster>();
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
        Sequence fadeOutSequence = DOTween.Sequence();
        fadeOutSequence.Append(text.DOFade(0, fadeDuration))
               .InsertCallback(fadeDuration - 0.1f, () => bootUp_Script.FadeIn())
               .OnComplete(() => raycaster.enabled = false);
    }
}
