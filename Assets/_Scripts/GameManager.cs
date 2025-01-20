using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;


public class GameManager : Singleton<GameManager>
{

    public int totalPoints;
    public TMP_Text scoreText;

    public static Canvas gameHUD;

    public List<AudioClip> NPC_hit_sounds;

    GameObject floatingTextPrefab;

    protected override void Awake()
    {
        
        base.Awake();
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        Target.TargetHit += AddPoints;
        EventManager.TimerStop += GameOver;
        SceneManager.sceneLoaded += StartRound;
    }

    void OnDisable()
    {
        Target.TargetHit -= AddPoints;
        EventManager.TimerStop -= GameOver;
        SceneManager.sceneLoaded -= StartRound;
    }

    private void StartRound(Scene arg0, LoadSceneMode arg1)
    {
        
        EventManager.OnTimerStart();
        if(totalPoints > 0)
        {
            totalPoints = 0;
        }
    }

    void Start()
    {
       
    }

    void GameOver()
    {
        //Everything that happens when the player runs out of time
        //Is Sent to the "You Failed screen" and can retry
        SceneManager.LoadSceneAsync(3);
        
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
        scoreText.text = totalPoints.ToString();
    }
    public void LosePoints(int points)
    {
        totalPoints -= points;
        scoreText.text = totalPoints.ToString();
    }
}
