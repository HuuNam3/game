using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collideHandle : MonoBehaviour
{
    public GameObject GameManager;
    public GameManager manage;

    public void Start()
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            manage.checkLose(true);
        }
        if (other.CompareTag("shoot"))
        {
            if(manage.checkEnemy(GetComponentInParent<Text>().text))
            {

                manage.deleteBullet(other.gameObject);
                WordDisplay display = GetComponentInParent<WordDisplay>();
                if (display != null)
                {
                    display.removeLetter();
                    if (display.getText() == 0)
                    {
                        manage.updateScore();
                        display.RemoveWord();
                        manage.GetWords().Remove(manage.targetWord());
                        manage.hasActiveWord = false;
                        manage.checkComplete();
                    }
                }
                else
                {
                    Debug.LogWarning("WordDisplay component not found on the parent of: " + other.name);
                }
                Vector3 parentPosition = transform.parent.position; // Lấy vị trí hiện tại của cha
                parentPosition.y += 0.15f; // Tăng trục Y thêm 5 đơn vị
                transform.parent.position = parentPosition;
            }
        }
    }
}
