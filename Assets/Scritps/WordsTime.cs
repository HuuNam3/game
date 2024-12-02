using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsTime : MonoBehaviour
{
    public GameManager WordManager;

    public float wordDelay = 1.0f;

    private float nextWordsTime = 0f;

    private void Start()
    {
        float mode = PlayerPrefs.GetFloat("Mode", 1);
        Debug.Log(this.wordDelay);
        Debug.Log(mode / 2);
        Debug.Log(this.wordDelay - mode / 2);
        this.wordDelay -= mode/2;
    }

    private void Update()
    {
        if (Time.time > nextWordsTime) 
        {
            WordManager.AddWord();
            nextWordsTime = Time.time + wordDelay;
            wordDelay *= .99f;
        }
    }
}
