using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadingAnimation_Script : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Lol";
    }
}
