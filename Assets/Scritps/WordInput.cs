using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public GameManager WordManager;
    private void Update()
    {
        foreach(char letter in Input.inputString)
        {
            WordManager.Letter(letter); 
        }
    }
}
