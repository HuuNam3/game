using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ramdomEmeny : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject vatthe;
    private Sprite[] sprites;

    private GameManager gameManager;
    public void Start()
    {
        string map = PlayerPrefs.GetString("map", "map1");
        sprites = Resources.LoadAll<Sprite>(map);

        int randomIndex = UnityEngine.Random.Range(0, sprites.Length);
        Sprite randomElement = sprites[randomIndex];
        spriteRenderer.sprite = randomElement;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "shoot")
        {
           
        }
    }
}
