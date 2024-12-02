using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;

    public float speed = 1f;

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void removeLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }
    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
        float mode = PlayerPrefs.GetFloat("Mode", 1);
        this.speed += (mode/3);
    }
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            text.enabled = false;
        } else
        {
            text.enabled = true;
        }
        transform.Translate(0f, -speed*Time.deltaTime, 0f);
    }
}
