using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButtonScript : MonoBehaviour
{
    public GameObject[] windowPrefab;
    public bool offButton = false;

    private int currentSprite;

    private void Start()
    {
        currentSprite = GetComponent<IconSpriteSelector>().GetSpriteInt();
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.instance.GetComponent<SoundFX>().playClick();
            InstantiateWindow(currentSprite);
        }
    }

    void InstantiateWindow(int sprite)
    {
        if(GameObject.Find(windowPrefab[currentSprite].name + "(Clone)") == null)
        {
            Instantiate(windowPrefab[currentSprite], new Vector3(0, 20, 0), Quaternion.identity);
        }
    }
}
