using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitClick : MonoBehaviour
{
    int clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                GameManager.instance.GetComponent<SoundFX>().playClick();
                StartCoroutine(endSound());
                GameManager.instance.Quit();

            }
        }
    }

    IEnumerator endSound() 
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.GetComponent<SoundFX>().playOutro();
    }
}
