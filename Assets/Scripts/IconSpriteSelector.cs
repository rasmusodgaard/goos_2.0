using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteSelector { clock, calculator, music, mail, off };
public class IconSpriteSelector : MonoBehaviour
{
    public SpriteSelector CurrentSprite;

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
        if(mouseOver)
        {
            spriteRenderer.sprite = selSprites[(int)CurrentSprite];
        }
        else if(!mouseOver && !holding)
        {
            spriteRenderer.sprite = sprites[(int)CurrentSprite];
        }

        if(Input.GetMouseButtonUp(0))
        {
            holding = false;
        }
    }

    void OnMouseOver()
    {
        mouseOver = true;
        if(Input.GetMouseButton(0))
        {
            holding = true;
        }
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    public int GetSpriteInt()
    {
        return (int)CurrentSprite;
    }

}
