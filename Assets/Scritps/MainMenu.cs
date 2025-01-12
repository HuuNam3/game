using System;
using TMPro;
using Unity.VisualScripting;
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
    public Image sound;
    public Image effect;
    public Sprite[] listSprite;
    public bool soundValue;
    public bool effectValue;
    public TextMeshProUGUI textMeshProUGUI;
    public Animator animator;

    private void Start()
    {
        // admin mode
        //animator = GetComponent<Animator>();
        //if (animator != null)
        //{
        //    animator.enabled = true;
        //    animator.Play("Home_UI_Shows");
        //}
        this.admin();
        //this.unlockMode();
        //this.unlockLevel();
        //PlayerPrefs.DeleteAll();
        if (audioSource == null)
        {
            GameObject music = GameObject.FindGameObjectWithTag("Music");
            AudioSource audio = music.GetComponent<AudioSource>();
            if (PlayerPrefs.GetInt("Sound", 1) == 1)
            {
                audio.mute = false;
                soundValue = false;
            }
            else
            {
                audio.mute = true;
                soundValue = true;
            }
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame(int level)
    {
        SceneManager.LoadScene("gamePlay");
        PlayerPrefs.SetInt("Level", level);
    }

    public void showPanelSound()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            effect.sprite = listSprite[2];
            audioSource.mute = false;
            soundValue = false;
        }
        else
        {
            effect.sprite = listSprite[3];
            audioSource.mute = true;
            soundValue = true;
        }

        if (PlayerPrefs.GetInt("Effect", 1) == 1)
        {
            sound.sprite = listSprite[0];
            effectValue = false;
        }
        else
        {
            sound.sprite = listSprite[1];
            effectValue = true;
        }
    }

    public void unlockLevel()
    {
        int levelUnlock = PlayerPrefs.GetInt("LevelUnlock", 1);
        int mode = PlayerPrefs.GetInt("Mode", 1);
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock", 1);
        if (mode == 1)
        {
            textMeshProUGUI.text = "Easy";
        }
        else if (mode == 2)
        {
            textMeshProUGUI.text = "Nomal";
        }
        else if (mode == 3)
        {
            textMeshProUGUI.text = "Hard";
        }
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
        PlayerPrefs.SetInt("ModeUnlock", 3);
    }

    public void ToggleMute()
    {
        soundValue = !soundValue;
        if (!soundValue)
        {
            PlayerPrefs.SetInt("Sound", 1);
            if (listSprite[0] != null)
            {
                effect.sprite = listSprite[2];
            }
        } else
        {
            if(sound != null)
            {
                PlayerPrefs.SetInt("Sound", 0);
                effect.sprite = listSprite[3];
            }
        }
        audioSource.mute = soundValue;
    }

    public void ToggleEffectMute()
    {
        effectValue = !effectValue;
        if (!effectValue)
        {
            PlayerPrefs.SetInt("Effect", 1);
            sound.sprite = listSprite[0];
            
        }
        else
        {
            PlayerPrefs.SetInt("Effect", 0);
            sound.sprite = listSprite[1];
        }
    }
}
