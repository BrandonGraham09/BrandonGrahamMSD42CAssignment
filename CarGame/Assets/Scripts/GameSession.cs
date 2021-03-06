﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    //make sure that only 1 GameSession is running
    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    // add scoreValue to score
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        if (score >= 100)
        {
            Level.LoadWinner();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
