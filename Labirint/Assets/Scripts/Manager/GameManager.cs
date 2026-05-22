using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;
    
    
    AudioSource sfxAudioSource;

    public AudioClip pauseClip;
    public AudioClip resumeClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public MusicManager musicManager;


    //UI
    public TextMeshProUGUI redKeyText;
    public TextMeshProUGUI greenKeyText;
    public TextMeshProUGUI goldKeyText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;
    public GameObject snowFlakeImage;

    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subTitleText;

    public TextMeshProUGUI useText;

    void Start()
    {
        if (gameManager == null) gameManager = this;
        sfxAudioSource = GetComponent<AudioSource>();
        InvokeRepeating("Stopper",2,1);
        redKeyText.text = "000";
        greenKeyText.text = "000";
        goldKeyText.text = "000";
        pointsText.text = "000";
        timeText.text = timeToEnd.ToString() + " s";
        snowFlakeImage.SetActive(false);
        infoPanel.SetActive(false);
        useText.text = "";
        Time.timeScale = 1f;
    }
    public void PlayClip(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.Play();
    }
    void Update()
    {
        PauseCheck();
        if (endGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Application.Quit();
            }
        }
        if(gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }
    }
    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused) ResumeGame();
            else PauseGame();
        }
    }
    void Stopper()
    {
        timeToEnd--;
        timeText.text = timeToEnd.ToString() + " s";
        snowFlakeImage.SetActive(false);
        if (timeToEnd <= 0 )
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }
    public void PauseGame()
    {
        infoPanel.SetActive(true);
        titleText.text = "PAUSED";
        subTitleText.text = "";
        useText.text = "Press [P] to Resume\n Press [E] to Exit";
        Time.timeScale = 0f;
        musicManager.OnGamePause();
        PlayClip(pauseClip);
        gamePaused = true;
    }
    public void ResumeGame()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1f;
        useText.text = "";
        musicManager.OnGameResume();
        PlayClip(resumeClip);
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            infoPanel.SetActive(true);
            titleText.text = "You Win!!";
            subTitleText.text = "Congratulation Play Again?";
            useText.text = "Restart? [Y/N]";
            PlayClip(winClip);
        }
        else
        {
            infoPanel.SetActive(true);
            titleText.text = "You Lose!!";
            subTitleText.text = "Play Again";
            useText.text = "Restart? [Y/N]";
            PlayClip(loseClip);
        }

    }
    public void AddPoints(int addPoint)
    {
        points += addPoint;
        pointsText.text = points.ToString("000");
    }
    public void AddKey(KeyColor color,int count = 1)
    {
        if (color == KeyColor.Gold)
        {
            goldKey += count;
            goldKeyText.text = goldKey.ToString("000");
        }
        else if (color == KeyColor.Green)
        {
            greenKey +=count;
            greenKeyText.text = greenKey.ToString("000");
        }
        else if (color == KeyColor.Red)
        {
            redKey += count;
            redKeyText.text = redKey.ToString("000");
        }
    }
    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
        timeText.text = timeToEnd.ToString() + " s";
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        snowFlakeImage.SetActive(true);
        InvokeRepeating("Stopper", freeze, 1);
    }
    public void SetUseText(string info)
    {
        useText.text = info;
    }

    public void WinGame()
    {
        win = true;
        endGame = true;
    }
    public void LoseGame()
    {
        win = false;
        endGame = true;
    }
    
}