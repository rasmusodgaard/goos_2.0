using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.Serialization;
using System;

public class BootUp_Script : MonoBehaviour
{

    ParticleSystem particle;
    public Transform buttonCanvas;
    Camera cam;

    [Header("Values after pressed")]
    public float particleSpeed = 10;
    public float particleAnimationDuration = 2;

    [OdinSerialize]
    public Gradient pressedGradient;

    [Header("CRT Shutters")]
    public Sprite shutterSprite;
    public Color spriteColor;
    private SpriteRenderer CRTShutter;

    private void Awake()
    {
        cam = Camera.main;
        particle = GetComponentInChildren<ParticleSystem>();
        CRTShutter = CreateCRTSprite();
    }

    public void BootUp()
    {
        //Loading particle modules
        var main = particle.main;
        var colorOverLifetime = particle.colorOverLifetime;

        //click sound played here


        //Boot animation:
        particle.Clear();
        //Particle system
        main.startLifetime = 10;
        main.simulationSpeed = 10;
        main.maxParticles = 30;

        colorOverLifetime.color = pressedGradient;

        //  -CRT simulation
        //      -Horisontal cover to 1%
        //      -Vertical covers to 1%
        //      -Noget med blur/glow
        AnimateCRTShutter(CRTShutter);
    }

    private void AnimateCRTShutter(SpriteRenderer input)
    {
        SoundFX soundFX = GameManager.instance.GetComponent<SoundFX>();
        soundFX.PlayButtonClick(true);
        soundFX.playSound(ref soundFX.pre_boot);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => soundFX.playSound(ref soundFX.boot_up, 0.7f))
            .Append(input.DOFade(1, 0.05f).SetEase(Ease.InQuad))
            .Append(input.transform.DOScaleX(53, 0.4f).SetEase(Ease.InQuad))
            .Append(input.transform.DOScaleY(33, 0.4f).SetEase(Ease.InQuad))
            .AppendCallback(GameManager.instance.NextScene)
            .PrependInterval(soundFX.pre_boot.length);
    }

    private SpriteRenderer CreateCRTSprite()
    {
        GameObject go = new GameObject();

        //RectTransform
        SpriteRenderer output = go.AddComponent<SpriteRenderer>();
        output.color = spriteColor;
        output.sprite = shutterSprite;
        output.sortingOrder = 10;

        return output;
    }
}
