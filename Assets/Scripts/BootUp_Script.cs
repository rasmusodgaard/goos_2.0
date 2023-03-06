using DG.Tweening;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class BootUp_Script : MonoBehaviour
{

    ParticleSystem particle;
    Camera cam;
    Image[] buttonImages;
    Button powerButton;

    public Transform buttonCanvas;

    [Header("Fade In settings")]
    public float fadeDuration = 1;
    public Ease fadeEase;

    [Header("Values after pressed")]
    public float particleSpeed = 10;
    public float particleAnimationDuration = 2;

    [OdinSerialize]
    public Gradient pressedGradient;

    [Header("CRT Shutters")]
    public Sprite shutterSprite;
    public Color spriteColor;

    private SpriteRenderer CRTShutter;
    private Sequence bootSequence = null;

    private void Awake()
    {
        cam = Camera.main;
        particle = GetComponentInChildren<ParticleSystem>();
        CRTShutter = CreateCRTSprite();
        buttonImages = buttonCanvas.GetComponentsInChildren<Image>();
        powerButton = buttonCanvas.GetComponentInChildren<Button>();

        for (int i = 0; i < buttonImages.Length; i++)
        {
            buttonImages[i].color = new Color(buttonImages[i].color.r, buttonImages[i].color.g, buttonImages[i].color.b, 0);
        }
    }

    public void FadeIn()
    {
        particle.Play();
        Sequence fadeInSequence = DOTween.Sequence();
        fadeInSequence.SetEase(fadeEase)
            .Append(buttonImages[0].DOFade(1, fadeDuration))
            .Join(buttonImages[1].DOFade(1, fadeDuration))
            .OnComplete(() => powerButton.interactable = true);
    }

    /// <summary>
    /// Function called by the power button when pressed.
    /// <para>Assigned in Editor.</para>
    /// </summary>
    public void BootUp()
    {
        if (bootSequence != null)
        {
            return;
        }

        //Loading particle modules
        var main = particle.main;
        var colorOverLifetime = particle.colorOverLifetime;


        particle.Clear();
        main.startLifetime = 10;
        main.simulationSpeed = 10;
        main.maxParticles = 30;

        colorOverLifetime.color = pressedGradient;

        AnimateCRTShutter(CRTShutter);
    }

    private void AnimateCRTShutter(SpriteRenderer input)
    {
        SoundFX soundFX = GameManager.instance.GetComponent<SoundFX>();
        soundFX.PlayButtonClick(true);
        soundFX.playSound(ref soundFX.pre_boot);
        bootSequence = DOTween.Sequence();
        bootSequence
            .PrependInterval(soundFX.pre_boot.length - 1)
            .AppendCallback(() => soundFX.playSound(ref soundFX.boot_up, 0.7f))
            .Append(input.DOFade(1, 0.05f).SetEase(Ease.InQuad))
            .Append(input.transform.DOScaleX(53, 0.4f).SetEase(Ease.InQuad))
            .Append(input.transform.DOScaleY(33, 0.4f).SetEase(Ease.InQuad))
            .AppendCallback(GameManager.instance.NextScene);
    }

    private SpriteRenderer CreateCRTSprite()
    {
        GameObject go = new GameObject();
        go.name = "CRT Shutter";
        SpriteRenderer output = go.AddComponent<SpriteRenderer>();
        output.color = spriteColor;
        output.sprite = shutterSprite;
        output.sortingOrder = 10;

        return output;
    }
}
