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
            bool activation = (usernamescript.GetLettersLength() > 0) ? true : false;
            GameManager.instance.GetComponent<SoundFX>().PlayButtonClick(activation);
            if (activation && clear.IsMoving == false)
            {
                InitiateDone();
            }
        }
    }

    void InitiateDone()
    {
        GameManager.instance.addUsername(usernamescript.ReturnAndLockUsername());
        clear.StartClearScreen();
    }
}

