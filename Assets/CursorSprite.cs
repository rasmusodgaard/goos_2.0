using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSprite : MonoBehaviour
{
    public Sprite normalCursor;
    public Sprite dragCursor;
    private SpriteRenderer spriteRenderer;
    private bool over = false;
    private bool holding = false;

    private Transform t;
    private Vector3 mpos;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalCursor;
        Cursor.visible = false;
        t = GetComponent<Transform>();
        mpos = Vector3.zero;
    }

    void Update()
    {
        mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mpos = new Vector3(mpos.x, mpos.y, -1);
        t.position = mpos;

        if (!over) { spriteRenderer.sprite = normalCursor; }
        else { spriteRenderer.sprite = dragCursor; }

        RayCasting();
    }

    void RayCasting(){
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Icon" || hit.collider.tag == "Window" || hit.collider.tag == "VolumeSlider") { over = true; }
            else if(over && hit.collider.tag == "Background" && !holding){
                over = false;
            }
        }

        if (over & Input.GetMouseButtonDown(0)) { holding = true; }
        if (Input.GetMouseButtonUp(0)) { holding = false; }
    }
}
