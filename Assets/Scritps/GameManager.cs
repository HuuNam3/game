using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [Header("Word")]
    public List<Word> words;
    public bool hasActiveWord;
    public bool isActive;
    public Word activeWord;
    public WordSpawner spawner;

    [Header("Bullet effected")]
    private GameObject prefeb;
    public List<GameObject> listprefeb;
    public Transform player;
    public GameObject[] bullet;
    public int target;

    [Header("UI")]
    public Text UIFalse;
    public Text UIScore;
    public Text UIRScore;
    public Text UIRFalse;
    public Text UIRWPM;
    public Text UILevel;
    public Text textPrefab;
    public Button BtnPause;
    public GameObject UIPanelResult;
    public GameObject UIPanelPause;
    public GameObject UIOver;
    public GameObject UIComplete;
    public GameObject UIHome;
    public GameObject UINext;
    public GameObject UIRestart;

    [Header("Value")]
    public int VScore = 0;
    public int VHighScore = 0;
    public int VWords = 0;
    public int VFalse = 0;
    public float VWPM = 0f;
    public float VGameStartTime;

    [Header("Game play")]
    public int level;
    public bool pause = false;
    public bool complete = false;

    [Header("Gun")]
    public GameObject gun;
    public Sprite[] listGun;

    [Header("Sound")]
    public AudioSource audioSource;

    [Header("Effect")]
    public AudioSource audioClip;

    [Header("backGround")]
    public SpriteRenderer background;
    //public MainMenu menu;
    public Sprite[] listSprite;
    public Image sound;
    public Image effect;

    void Start()
    {
        this.ContinueGame();
        this.ramdomMap();
        this.setLevel();
        this.setGun();
        this.VGameStartTime = Time.time;
        //menu = new MainMenu();
        listprefeb = new List<GameObject>();
    }

    public void setGun()
    {
        int idx = PlayerPrefs.GetInt("Gun", 0);

        if (idx == 0 || gun == null)
        {
            Debug.LogWarning("Gun GameObject is not assigned or no gun is selected.");
            return;
        }

        SpriteRenderer gunSpriteRenderer = gun.GetComponent<SpriteRenderer>();
        if (gunSpriteRenderer == null)
        {
            Debug.LogError("Gun GameObject does not have a SpriteRenderer component!");
            return;
        }

        if (idx > 0 && idx <= listGun.Length)
        {
            gunSpriteRenderer.sprite = listGun[idx - 1];
        }
        else
        {
            Debug.LogError("Gun index is out of range!");
        }
    }

    private void Update()
    {
        this.checkPauseGame();
        if (this.pause == false)
        {
            if (isActive)
            {
                if (listprefeb.Count < words[0].getDisplay().getText())
                {
                    prefeb = Instantiate(bullet[PlayerPrefs.GetInt("Gun", 1) - 1], new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Quaternion.Euler(0, 0, 90));
                    if (prefeb != null)
                    {
                        AudioSource audio = prefeb.GetComponent<AudioSource>();
                        if (PlayerPrefs.GetInt("Effect", 1) == 1)
                        {
                            audio.mute = false;
                        }
                        else
                        {
                            audio.mute = true;
                        }
                        listprefeb.Add(prefeb);
                    }
                    //Destroy(prefeb, 1f);

                    this.zPlayer();
                }
                this.checkKeyTrue();
                isActive = false;
            }
        }
    }
    public void ramdomMap()
    {
    
        AudioClip[] audioList = Resources.LoadAll<AudioClip>("audio");
        Sprite[] backGroundList = Resources.LoadAll<Sprite>("bg");
        int randomIndex = UnityEngine.Random.Range(0, audioList.Length);

        Debug.Log(audioList.Length);
        Debug.Log(randomIndex);
        if (randomIndex == 0)
        {
            this.UIFalse.color = Color.black;
            this.UIScore.color = Color.black;
            this.UILevel.color = Color.black;
            this.textPrefab.color = Color.red;
        }
        else if (randomIndex == 1) {
            this.UIFalse.color = Color.yellow;
            this.UIScore.color = Color.yellow;
            this.UILevel.color = Color.yellow;
            this.textPrefab.color = Color.white;
        }
        else if (randomIndex == 2)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.blue;
        }
        else if (randomIndex == 3)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.yellow;
        }
        else if (randomIndex == 4)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.red;
        }
        else if (randomIndex == 5)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.yellow;
        }
        else if (randomIndex == 6)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.yellow;
        }
        else if (randomIndex == 7)
        {
            this.UIFalse.color = Color.white;
            this.UIScore.color = Color.white;
            this.UILevel.color = Color.white;
            this.textPrefab.color = Color.green;
        }

        audioSource.clip = audioList[randomIndex];
        background.sprite = backGroundList[randomIndex];
        PlayerPrefs.SetString("map", audioSource.clip.name);
        audioSource.Play();
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            audioSource.mute = false;
        } else
        {
            audioSource.mute = true;
        }
    }
    public void deleteBullet(GameObject prefab)
    {
        if (listprefeb.Contains(prefab)) // Kiểm tra xem prefab có trong danh sách không
        {
            listprefeb.Remove(prefab); // Xóa prefab khỏi danh sách
            Destroy(prefab); // Hủy đối tượng khỏi cảnh
            //Debug.Log("Bullet deleted and removed from list: " + prefab.name);
        }
    }
    public void updateScore()
    {
        this.VScore++;
        this.UIScore.text = "Score: " + this.VScore;
    }

    public void updateFalse()
    {
        this.VFalse++;
        this.UIFalse.text = "False: " + this.VFalse;
    }

    public void pauseGame()
    {
        this.pause = true;
    }

    public void ContinueGame()
    {
        this.pause = false;
        this.UIPanelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
    }

    public void checkPauseGame()
    {
        if(this.pause)
        {
            BtnPause.enabled = false;
            Time.timeScale = 0;
        } else
        {
            BtnPause.enabled = true;
        }
    }

    public void setLevel()
    {
        this.level = PlayerPrefs.GetInt("Level", 1);
        UILevel.text = "Level: " + this.level;
        WordGenerator.setValueCurrLevel(this.level);
    }

    public void checkLose(bool lose)
    {
        if (this.VFalse > 5 || lose == true)
        {
            this.resultValue(false);
            this.UIPanelResult.SetActive(true);
            this.pause = true;
            this.words.Clear();
        }
    }

    public void checkComplete()
    {
        int lengthCurrLevel = WordGenerator.getLengthCurrLevel();
        if (this.level % 14 == 0)
        {
            if (this.VScore == 50)
            {
                this.handleComplete();
            }
        }
        else if (this.words.Count == 0 && lengthCurrLevel == 0)
        {
            this.handleComplete();
        }
    }

    private void handleComplete()
    {
        int Mode = PlayerPrefs.GetInt("Mode", 1);
        int modeUnlock = PlayerPrefs.GetInt("ModeUnlock", 1);
        int unlockLevel = this.level + 1 + (Mode - 1) * 14;
        if (unlockLevel >= 30 && modeUnlock < 3)
        {
            PlayerPrefs.SetInt("ModeUnlock", 3);
        }
        else if (unlockLevel >= 15 && modeUnlock < 2)
        {
            PlayerPrefs.SetInt("ModeUnlock", 2);
        }
        PlayerPrefs.SetInt("LevelUnlock", unlockLevel);
        this.resultValue(true);
        UIPanelResult.SetActive(true);
        this.pause = true;
        this.words.Clear();
    }

    public void resultValue(bool win)
    {
        this.updateWPM();
        this.UIRScore.text = "Score: " + this.VScore;
        this.UIRFalse.text = "False: " + this.VFalse;
        this.UIRWPM.text = "WPM: " + this.VWPM;

        if(win)
        {
            this.UINext.SetActive(true);
            this.UIComplete.SetActive(true);
            this.UIRestart.SetActive(false);
            this.UIOver.SetActive(false);
        } else
        {
            this.UINext.SetActive(false);
            this.UIComplete.SetActive(false);
            this.UIRestart.SetActive(true);
            this.UIOver.SetActive(true);
        }
    }

    public void checkKeyTrue()
    {
        this.VWords++;
    }

    public void updateWPM()
    {
        this.VWPM = CalculateWPM();
        this.UIRWPM.text = "WPM: " + (int)this.VWPM;
    }

    public void exit()
    {
        SceneManager.LoadScene("menu");
    }

    public void nextlevel()
    {
        if(this.level % 14 == 0)
        {
            int mode = PlayerPrefs.GetInt("Mode", 1);
            mode++;
            PlayerPrefs.SetInt("Mode", mode);
        }else
        {
            this.level++;
        }
        PlayerPrefs.SetInt("Level", this.level);
        SceneManager.LoadScene("gamePlay");
    }

    public void RestartLevel()
    {
        PlayerPrefs.SetInt("Level", this.level);
        SceneManager.LoadScene("gamePlay");
    }

    public float CalculateWPM()
    {
        float timeElapsed = (Time.time - this.VGameStartTime) / 60f;
        if (timeElapsed > 0)
        {
            // Tính CPM.
            float wpms = this.VWords /5*timeElapsed;

            // Làm tròn cpms thành số nguyên.
            wpms = Mathf.Round(wpms);

            // Trả về kết quả.
            return wpms;
        }

        // Trả về 0 nếu thời gian không hợp lệ.
        return 0f;
    }


    public void AddWord()
    {
        if (this.pause == false)
        {
            string wordRamdom = WordGenerator.GetRandomWord(level);
            if (wordRamdom != "")
            {
                Word word = new Word(wordRamdom, spawner.SpawnWord());
                words.Add(word);
            }
        }
    }

    public List<Word> GetWords()
    {
        return words;
    }

    public GameObject targetEnemy()
    {
        if(words.Count == 0) return null;
        return words[this.target].getDisplay().gameObject;
    }

    public bool checkEnemy(string name)
    {
        if (words[this.target] == null)
        {
            return false;
        } else
        {
            return words[this.target].getDisplay().text.text == name;
        }
    }

    public Word targetWord()
    {
        return words[this.target];
    }

    public void zPlayer()
    {
        if(words.Count == 0)
        {
            return;
        }
        double angleDegree = Math.Atan(words[0].getDisplay().transform.position.x / words[0].getDisplay().transform.position.y) * (180 / Math.PI);
        this.player.rotation = Quaternion.Euler(new Vector3(0, 0, (float)-angleDegree));
    }

    bool letterKey()
    {
        foreach (char c in Input.inputString)
        {
            if (char.IsLetter(c))
            {
                return true;
            }
        }
        return false;
    }

    public void Letter(char letter)
    {
        if (this.pause == false)
        {
            if (hasActiveWord && activeWord != null)
            {
                //Debug.Log(activeWord.getDisplay().text.text.Length);
                //Debug.Log(this.listprefeb.Count);
                int idx = this.listprefeb.Count;
                if (this.listprefeb.Count >= activeWord.getDisplay().text.text.Length) return;
                Debug.Log(activeWord.getDisplay().text.text[idx]);
                Debug.Log(letter);
                if (activeWord.getDisplay().text.text.Length != 0)
                {
                    if (activeWord.getDisplay().text.text[idx] == letter)
                    {
                        //activeWord.typeLetter();
                        //this.deleteKey();
                        isActive = true;
                    } else
                    {
                        this.updateFalse();
                        this.checkLose(false);
                    }
                }
            }
            else
            {
                bool s = true;
                foreach (Word word in words)
                {
                    if (word.GetNextLetter() == letter)
                    {
                        this.target = words.IndexOf(word);
                        activeWord = word;
                        activeWord.getDisplay().setColor();
                        hasActiveWord = true;
                        //this.deleteKey();
                        //word.typeLetter();
                        isActive = true;
                        s = false;
                        break;
                    }
                }
                if (s)
                {
                    this.updateFalse();
                    this.checkLose(false);
                }
            }

            if (hasActiveWord && activeWord != null && activeWord.Typed())
            {
                hasActiveWord = false;
                //words.Remove(activeWord);
                this.updateScore();
                this.checkComplete();
            }
        }
    }

    public void showUiSound()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            sound.sprite = listSprite[0];
        }
        else
        {
            sound.sprite = listSprite[1];
        }

        if (PlayerPrefs.GetInt("Effect", 1) == 1)
        {
            effect.sprite = listSprite[2];
        }
        else
        {
            effect.sprite = listSprite[3];
        }
    }

    public void ToggleMute()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            PlayerPrefs.SetInt("Sound", 0);
            audioSource.mute = true;
            sound.sprite = listSprite[1];
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            audioSource.mute = false;
            sound.sprite = listSprite[0];
        }
    }

    public void ToggleEffectMute()
    {
        if (PlayerPrefs.GetInt("Effect", 1) == 1)
        {
            PlayerPrefs.SetInt("Effect", 0);
            effect.sprite = listSprite[3];
        }
        else
        {
            PlayerPrefs.SetInt("Effect", 1);
            effect.sprite = listSprite[2];
        }
    }
}

