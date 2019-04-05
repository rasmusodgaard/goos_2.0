using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpriteSelector : MonoBehaviour
{
    public int currentSprite;

    [Header("Sprite Arrays")]
    public Sprite[] sprites;
    public Sprite[] selSprites;

    private bool mouseOver = false;
    private bool holding = false;


    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (mouseOver) { spriteRenderer.sprite = selSprites[currentSprite]; }
        else if(!mouseOver && !holding) { spriteRenderer.sprite = sprites[currentSprite]; }

        if (Input.GetMouseButtonUp(0)) { holding = false; }
    }

    void OnMouseOver()
    {
        mouseOver = true;
        if (Input.GetMouseButton(0)) { holding = true; }
    }

     void OnMouseExit()
    {
        mouseOver = false;
    }
    

}
