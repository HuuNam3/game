using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button[] levelBtn;
    public Button[] modeBtn;
    public Sprite spriteLock;

    private void Start()
    {
        // admin mode 
        this.admin();
    }

    public void PlayGame(int level)
    {
        SceneManager.LoadScene("gamePlay");
        PlayerPrefs.SetInt("Level", level);
    }

    public void unlockLevel()
    {
        int level = PlayerPrefs.GetInt("LevelUnlock", 1);
        float mode = PlayerPrefs.GetFloat("Mode");
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock");
        if(modeUnlock <= mode)
        {
            for (int i = levelBtn.Length - 1; i >= level; i--)
            {
                levelBtn[i].enabled = false;
                levelBtn[i].image.sprite = spriteLock;
            }
        } else
        {
            for (int i = levelBtn.Length - 1; i > 12; i--)
            {
                levelBtn[i].enabled = false;
                levelBtn[i].image.sprite = spriteLock;
            }
        }
    }

    public void unlockMode()
    {
        int mode = PlayerPrefs.GetInt("ModeUnlock", 1);
        for (int i = modeBtn.Length - 1; i >= mode; i--)
        {
            modeBtn[i].enabled = false;
            modeBtn[i].image.sprite = spriteLock;
        }
    }

    public void setMode(float mode)
    {
        PlayerPrefs.SetFloat("Mode", mode);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        //Application.Quit();
    }

    public void admin()
    {
        PlayerPrefs.SetInt("LevelUnlock", 13);
        PlayerPrefs.SetInt("ModeUnlock", 6);
    }
}
