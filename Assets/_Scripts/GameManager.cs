using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : Singleton<GameManager>
{

    public int totalPoints;
    public TMP_Text scoreText;

    protected override void Awake()
    {
        base.Awake();
        EventManager.OnTimerStart();
    }

    // Update is called once per frame
    void OnEnable()
    {
        Target.TargetHit += AddPoints;
    }

    void OnDisable()
    {
        Target.TargetHit -= AddPoints;
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
}
