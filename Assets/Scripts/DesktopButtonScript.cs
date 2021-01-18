using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButtonScript : MonoBehaviour
{
    public GameObject[] windowPrefab;
    public bool offButton = false;

    private int currentSprite;
    private string windowName = "Window(Clone)";

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
        GameObject window = GameObject.Find(windowPrefab[currentSprite].name + "(Clone)");
        Vector3 spawnPosition = new Vector3(0, 20, 0);

        if(window == null)
        {
            Instantiate(windowPrefab[currentSprite], spawnPosition, Quaternion.identity).transform.parent = this.transform;
        }
        else if(window.name == windowName)
        {
            // Stop unlimited windows
            if(transform.childCount >= 6)
            {
                return;
            }

            // Check for gameobjects at the spawn position
            Collider[] occupants = Physics.OverlapBox(spawnPosition, Vector3.one);

            // If spawnposition is occupied, move up and check again until available
            foreach(var occupant in occupants)
            {
                if(occupant.name == windowName)
                {
                    spawnPosition += (Vector3.up * occupant.bounds.extents.y * 2);
                    while(Physics.OverlapBox(spawnPosition, Vector3.one).Length > 0)
                    {
                        spawnPosition += (Vector3.up * occupant.bounds.extents.y * 2);
                    }
                    break;
                }
            }

            // Spawn as 
            Instantiate(windowPrefab[currentSprite], spawnPosition, Quaternion.identity).transform.parent = this.transform;
        }
        else
        {
            return;
        }
    }
}
