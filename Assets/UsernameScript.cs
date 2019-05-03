using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameScript : MonoBehaviour
{

    public Text text;

    public List<GameObject> letters;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharSphere")
        {
            letters.Add(other.gameObject);
            UpdateUsername();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CharSphere")
        {
            letters.Remove(other.gameObject);
            UpdateUsername();
        }
    }


    private void UpdateUsername() 
    {
        text.text = "";
        foreach (GameObject letter in letters)
        {
            text.text += letter.GetComponentInChildren<Text>().text;
        }
    }
}
