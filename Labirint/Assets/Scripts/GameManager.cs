using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        if (gameManager == null) gameManager = this;
        if (timeToEnd <= 0) timeToEnd = 100;
        InvokeRepeating("Stopper",2,1);
    }
    void Update()
    {
        PauseCheck();
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
        Debug.Log("Time: " + timeToEnd + " s");
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
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("you win!! relod?");
        }
        else
        {
            Debug.Log("you lose!! reload?");
        }

    }
    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddKey(KeyColor color)
    {
        if (color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if (color == KeyColor.Red)
        {
            redKey++;
        }
    }
    public void AddTime(int addtime)
    {
        timeToEnd += addtime;
    }
    public void FreezeTime(int freeze)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freeze, 1);
    }
}