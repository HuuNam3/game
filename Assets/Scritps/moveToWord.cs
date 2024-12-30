using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToWord : MonoBehaviour
{
    public GameObject GameManager;
    public GameManager manage;

    private void Start()
    {
        if (GameManager == null)
        {
            GameManager = GameObject.FindWithTag("GameManage");
            if (GameManager != null)
            {
                manage = GameManager.GetComponent<GameManager>(); // Gán script GameManager
            }
            else
            {
                Debug.LogError("GameManager not found. Ensure an object with tag 'GameManage' exists.");
            }
        }
    }

    private void Update()
    {
        
        GameObject target = manage.targetEnemy();
        if (target != null)
        {
            Vector3 position = new Vector3(target.transform.position.x, target.transform.position.y + -0.05f, target.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, position, 14 * Time.deltaTime);
        }
    }
}
