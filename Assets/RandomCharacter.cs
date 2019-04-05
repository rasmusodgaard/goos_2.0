using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCharacter : MonoBehaviour
{
    public Text Character;

    char[] characters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                        'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'X', 'Y', 'Z',
                        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '#', '%',
                         '&', '?' };
            
    
    

    void Start()
    {
        Character.text = characters[Random.Range(0, characters.Length)].ToString();
    }


 

}
