using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUsername : MonoBehaviour
{
    private Text username;
    void Start()
    {
        //GetComponent<Text>().text = GameManager.instance.GetComponent<UsernameScript>().GetUsername();
        username = GetComponent<Text>();
        username.text = GameManager.instance.GetUserName();
    }
}
