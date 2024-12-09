using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using Image = UnityEngine.UI.Image;

public class MainMenu : MonoBehaviour
{

    public Button[] levelBtn;
    public Button[] modeBtn;
    public Sprite spriteLock;

    private void Start()
    {
        // admin mode 
        unlockMode();
        unlockLevel();
        //this.admin();
    }

    public void PlayGame(int level)
    {
        SceneManager.LoadScene("gamePlay");
        PlayerPrefs.SetInt("Level", level);
    }

    public void unlockLevel()
    {
        int level = PlayerPrefs.GetInt("LevelUnlock", 1);
        //Debug.Log(level);
        float mode = PlayerPrefs.GetFloat("Mode");
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock");
        for (int i = levelBtn.Length - 1; i >= level; i--)
        {
            levelBtn[i].enabled = false;
            levelBtn[i].image.sprite = spriteLock;
        }
        //if (modeUnlock <= mode)
        //{
        //    for (int i = levelBtn.Length - 1; i >= level; i--)
        //    {
        //        levelBtn[i].enabled = false;
        //        levelBtn[i].image.sprite = spriteLock;
        //    }
        //}
        //else
        //{
        //    for (int i = levelBtn.Length - 1; i > 12; i--)
        //    {
        //        levelBtn[i].enabled = false;
        //        levelBtn[i].image.sprite = spriteLock;
        //    }
        //}
    }

    public void unlockMode()
    {
        int mode = PlayerPrefs.GetInt("ModeUnlock", 1);
        for (int i = modeBtn.Length - 1; i >= mode; i--)
        {
            //opacity
            Image buttonImage = modeBtn[i].GetComponent<Image>();
            Color color = buttonImage.color;
            color.a = Mathf.Clamp01(0.6f);
            buttonImage.color = color;

            modeBtn[i].enabled = false;
        }
    }

    public void setMode(float mode)
    {
        PlayerPrefs.SetFloat("Mode", mode);
    }

    public void setGun(int gun)
    {
        PlayerPrefs.SetInt("Gun", gun);
    }

    public void QuitGame()
    {
        //PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void admin()
    {
        PlayerPrefs.SetInt("LevelUnlock", 13);
        PlayerPrefs.SetInt("ModeUnlock", 3);
    }
}
