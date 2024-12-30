using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;

    public Transform parent;
    public WordDisplay SpawnWord ()
    {
        Vector2 position = new Vector2(Random.Range(-7f,7f),6);
        GameObject wordObj = Instantiate(wordPrefab, position, Quaternion.identity, parent);
        WordDisplay wordDisplay =  wordObj.GetComponent<WordDisplay>();
        
        return wordDisplay;
    }
    
}
