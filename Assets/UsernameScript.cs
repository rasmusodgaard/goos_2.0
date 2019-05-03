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
        letters.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        letters.Remove(other.gameObject);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            text.text = "";
            foreach (GameObject letter in letters)
            {
                text.text += letter.GetComponentInChildren<Text>().text;
            }
            print(text.text);
        }
    }
}
