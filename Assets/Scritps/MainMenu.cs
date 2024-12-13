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
    public Sprite[] SpriteLevel;
    public AudioSource audioSource;

    private void Start()
    {
        // admin mode
        //this.admin();
        //this.unlockMode();
        //this.unlockLevel();
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            audioSource.Play();
        }
    }

    public void PlayGame(int level)
    {
        SceneManager.LoadScene("gamePlay");
        PlayerPrefs.SetInt("Level", level);
    }

    public void unlockLevel()
    {
        int levelUnlock = PlayerPrefs.GetInt("LevelUnlock", 1);
        int mode = PlayerPrefs.GetInt("Mode", 1);
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock", 1);
        Debug.Log(levelUnlock);
        Debug.Log(mode);
        Debug.Log(modeUnlock);
        for (int i = 1; i <= levelBtn.Length; i++)
        {
            if (modeUnlock > mode) {
                levelBtn[i - 1].enabled = true;
                levelBtn[i - 1].image.sprite = SpriteLevel[i - 1];
                continue;
            }
            if (levelUnlock - (mode - 1) * 14 >= i) {
                levelBtn[i - 1].enabled = true;
                levelBtn[i - 1].image.sprite = SpriteLevel[i - 1];
                continue;
            }
            levelBtn[i-1].enabled = false;
            levelBtn[i-1].image.sprite = spriteLock;
        }
    }

    public void unlockMode()
    {
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock", 1);
        int mode = PlayerPrefs.GetInt("Mode", 1);
        Debug.Log(modeUnlock);
        Debug.Log(mode);
        for (int i = 1; i <= modeBtn.Length; i++)
        {
            //opacity
            if(modeUnlock >= i) continue;
            Image buttonImage = modeBtn[i-1].GetComponent<Image>();
            Color color = buttonImage.color;
            color.a = Mathf.Clamp01(0.6f);
            buttonImage.color = color;
            modeBtn[i - 1].enabled = false;
        }
    }

    public void setMode(int mode)
    {
        PlayerPrefs.SetInt("Mode", mode);
    }

    public void setGun(int gun)
    {
        PlayerPrefs.SetInt("Gun", gun);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void admin()
    {
        PlayerPrefs.SetInt("LevelUnlock", 44);
    }

    public void turnOnSound()
    {
        audioSource.Play();
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void turnOffSound()
    {
        audioSource.Pause();
        PlayerPrefs.SetInt("Sound", 0);
    }
}
