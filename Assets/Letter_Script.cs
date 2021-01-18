using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter_Script : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Time for a break!";
    }
}
