using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter_Script : MonoBehaviour
{
    TextMeshProUGUI text;
    string[] quotes = { "Truth is ever to be found in the simplicity, and not in the multiplicity and confusion of things.",
                        "No great discovery was ever made without a bold guess.",
                        "If I have ever made any valuable discoveries, it has been due more to patient attention, than to any other talent.",
                        "If I have seen farther than others, it is because I was standing on the shoulders of giants.",
                        "To every action there is always an equal and opposite or contrary, reaction.",
                        "Live your life as an exclamation rather than an explanation.",
                        "If others would think as hard as I did, then they would get similar results.",
                        "What goes up must come down.",
                        "Tact is the knack of making a point without making an enemy.",
                        "A man may imagine things that are false, but he can only understand things that are true."};

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = quotes[Random.Range(0, quotes.Length)];
    }
}
