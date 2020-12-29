using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.Serialization;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class BootUp_Script : MonoBehaviour
{

    ParticleSystem particle;
    Transform canvasTransform;
    Camera cam;
    RectTransform[] shutters;
    Vector2[] clockwise;

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
        clockwise = new Vector2[]{
            Vector2.up, Vector2.right, Vector2.down, Vector2.left
        };
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
        //shutters = CreateCRTShutters();
        //      -Horisontal cover to 1%
        //      -Vertical covers to 1%
        //      -Noget med blur/glow
        GameManager.instance.TimedQuit(5);
    }

    private RectTransform[] CreateCRTShutters()
    {
        //Generate output variable and clockwise directions array (from up)
        RectTransform[] output = new RectTransform[4];

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

            //TODO: position shutters correctly around the screen and 
            ScaleAndMoveRect(output[i], 1, 1, clockwise[i]);
        }
        return output;
    }

    [Button]
    public void MoveDown()
    {
        foreach(var shutter in shutters)
        {
            shutter.position += Vector3.down;
        }
    }

    private void ScaleAndMoveRect(RectTransform input, float horizontalPercent, float verticalPercent, Vector2 positioning)
    {
        input.localScale = Vector3.one;
        Vector2 rectMiddle = new Vector2(0.5f, 0.5f) + positioning;

        input.sizeDelta = Vector2.zero; //Dont want any delta sizes, because that would defeat the point of anchors
        input.anchoredPosition = Vector2.zero; //And the position is set by the anchors aswell so we set the offset to 0

        input.anchorMin = new Vector2(rectMiddle.x - horizontalPercent / 2,
                                    rectMiddle.y - verticalPercent / 2);
        input.anchorMax = new Vector2(rectMiddle.x + horizontalPercent / 2,
                                    rectMiddle.y + verticalPercent / 2);
    }
}
