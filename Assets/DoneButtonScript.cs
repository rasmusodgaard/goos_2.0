using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonScript : MonoBehaviour
{
    private UsernameScript usernamescript;
    private ClearScreen clear;

    private int currentSprite;
    private int clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;

    private void Start()
    {
        usernamescript = GameObject.FindWithTag("Username").GetComponent<UsernameScript>();
        clear = GameObject.FindWithTag("BorderRight").GetComponent<ClearScreen>();
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                InitiateDone();

            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        }
    }

    void InitiateDone()
    {
        GameManager.instance.addUsername(usernamescript.ReturnAndLockUsername());
        clear.StartClearScreen();
    }
}

