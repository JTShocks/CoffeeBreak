using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0,1000)]
    public int targetScoreValue;
    public static event Action<int> TargetHit;
    public void OnHit()
    {
        Debug.Log("I've been shot!");
        //Play a random sound

        TargetHit?.Invoke(targetScoreValue);

    }
}
