using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    public GameObject[] windowPrefab;

    private int currentSprite;

    int clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    private void Start()
    {
        currentSprite = GetComponent<IconSpriteSelector>().GetSpriteInt();
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                Debug.Log(gameObject.name + " DOUBLE CLICKED");
                InstantiateWindow(currentSprite); 
            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        }
    }

    void InstantiateWindow(int sprite){
        Instantiate(windowPrefab[currentSprite], new Vector3(0, 20, 0), Quaternion.identity);
    }
}
