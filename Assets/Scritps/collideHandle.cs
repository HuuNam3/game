using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideHandle : MonoBehaviour
{
    public GameManager GameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("emeny"))
        {

            GameManager.checkLose(true);
        }
    }
}
