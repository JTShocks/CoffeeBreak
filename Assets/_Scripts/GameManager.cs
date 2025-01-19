using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;


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
    }

    void OnDisable()
    {
        Target.TargetHit -= AddPoints;
        EventManager.TimerStop -= GameOver;
    }

    void Start()
    {
        EventManager.OnTimerStart();
    }

    void GameOver()
    {
        //Everything that happens when the player runs out of time
        //Is Sent to the "You Failed screen" and can retry
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
