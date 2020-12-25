using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.Serialization;
using UnityEngine.UI;

public class BootUp_Script : MonoBehaviour
{

    ParticleSystem particle;
    Transform canvasTransform;
    Camera cam;

    [Header("Values after pressed")]
    public float particleSpeed = 10;
    public float particleAnimationDuration = 2;

    [OdinSerialize]
    public Gradient pressedGradient;

    [Header("CRT Shutters")]
    public Sprite shutterSprite;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        canvasTransform = GetComponentInChildren<Canvas>().transform;
        cam = Camera.main;
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
        RectTransform[] shutters = CreateCRTShutters();
        //      -Horisontal cover to 1%
        //      -Vertical covers to 1%
        //      -Noget med blur/glow
    }

    private RectTransform[] CreateCRTShutters()
    {
        //Generate output variable and clockwise directions array (from up)
        RectTransform[] output = new RectTransform[1];

        //Generating the game objects and their components
        for(int i = 0; i < output.Length; i++)
        {
            //Pre RectTransform
            GameObject go = new GameObject();
            go.transform.parent = canvasTransform;

            //RectTransform
            Image image = go.AddComponent<Image>();
            image.sprite = shutterSprite;
            output[i] = go.GetComponent<RectTransform>();


            ScaleRectToScreen(output[i], 1, 1);
        }



        return output;
    }

    private void ScaleRectToScreen(RectTransform input, float horizontalPercent, float verticalPercent)
    {
        input.localScale = Vector3.one;
        Vector2 rectMiddle = new Vector2(0.5f, 1.5f);

        input.sizeDelta = Vector2.zero; //Dont want any delta sizes, because that would defeat the point of anchors
        input.anchoredPosition = Vector2.zero; //And the position is set by the anchors aswell so we set the offset to 0

        input.anchorMin = new Vector2(rectMiddle.x - horizontalPercent / 2,
                                    rectMiddle.y - verticalPercent / 2);
        input.anchorMax = new Vector2(rectMiddle.x + horizontalPercent / 2,
                                    rectMiddle.y + verticalPercent / 2);
    }
}
