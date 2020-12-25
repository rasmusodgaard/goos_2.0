using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BootUp_Script : MonoBehaviour
{
    ParticleSystem particle;

    public float particleSpeed = 10;
    public float particleAnimationDuration = 2;
    public ParticleSystem.MinMaxGradient pressedGradient;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }
    public void BootUp()
    {
        var main = particle.main;
        var colorOverLifetime = particle.colorOverLifetime;
        //click sound

        //Boot animation
        //  -Blast out particles
        main.startLifetime = 10;
        main.simulationSpeed = 10;
        colorOverLifetime.color = pressedGradient;
        //  -CRT simulation
        //      -Horisontal cover to 1%
        //      -Vertical covers to 1%
        //      -Noget med blur/glow
    }
}
