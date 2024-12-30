using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class WordDisplay : MonoBehaviour
{
    public Text text;

    public float speed = 1f;

    public GameObject target;

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void removeLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
        if (PlayerPrefs.GetString("map") == "map1")
        {
            text.color = Color.blue;
        }
        else if (PlayerPrefs.GetString("map") == "map2")
        {
            text.color = Color.yellow;
        }
        else if (PlayerPrefs.GetString("map") == "map3")
        {
            text.color = Color.green;
        }
        else if (PlayerPrefs.GetString("map") == "map4")
        {
            text.color = Color.red;
        }
        else if (PlayerPrefs.GetString("map") == "map5")
        {
            text.color = Color.yellow;
        }
        else if (PlayerPrefs.GetString("map") == "map6")
        {
            text.color = Color.blue;
        }
        else if (PlayerPrefs.GetString("map") == "map7")
        {
            text.color = Color.red;
        }
        else if (PlayerPrefs.GetString("map") == "map8")
        {
            text.color = Color.red;
        }
    }

    public void setColor()
    {
        text.color = Color.red;
        if (PlayerPrefs.GetString("map") == "map1")
        {
            text.color = Color.blue;
        }
        else if (PlayerPrefs.GetString("map") == "map2")
        {
            text.color = Color.yellow;
        }
        else if (PlayerPrefs.GetString("map") == "map3")
        {
            text.color = Color.green;
        }
        else if (PlayerPrefs.GetString("map") == "map4")
        {
            text.color = Color.red;
        }
        else if (PlayerPrefs.GetString("map") == "map5")
        {
            text.color = Color.yellow;
        }
        else if (PlayerPrefs.GetString("map") == "map6")
        {
            text.color = Color.blue;
        }
        else if (PlayerPrefs.GetString("map") == "map7")
        {
            text.color = Color.red;
        }
        else if (PlayerPrefs.GetString("map") == "map8")
        {
            text.color = Color.red;
        }
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public int getText()
    {
        return this.text.text.Length;
    }

    public void Start()
    {
        float mode = PlayerPrefs.GetFloat("Mode", 1);
        target = GameObject.FindGameObjectWithTag("floor");
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
        Vector3 position = new Vector3(target.transform.position.x, target.transform.position.y + -0.05f, target.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, position, this.speed * Time.deltaTime);
        //transform.Translate(0f, -speed*Time.deltaTime, 0f);

    }
}
