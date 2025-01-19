using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI finalScore;
    void Awake()
    {
        finalScore.text = GameManager.Instance.totalPoints.ToString();
    }
}
