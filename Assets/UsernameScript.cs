using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameScript : MonoBehaviour
{

    public Text text;
    public List<GameObject> letters;

    private bool locked;
    private string username;

    private void Start() { locked = false; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharSphere" && !locked)
        {
            letters.Add(other.gameObject);
            UpdateUsername();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CharSphere" && !locked)
        {
            letters.Remove(other.gameObject);
            UpdateUsername();
        }
    }


    private void UpdateUsername() 
    {
        text.text = "";
        username = "";
        foreach (GameObject letter in letters)
        {
            text.text += letter.GetComponentInChildren<Text>().text;
            username = text.text;
        }
    }

    public string ReturnAndLockUsername() 
    {
        locked = true;
        return username;
    }

    public string GetUsername() { return username; }
}
