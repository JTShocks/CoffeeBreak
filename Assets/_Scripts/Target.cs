using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0,1000)]


    public int targetScoreValue;

    [Tooltip("How many hits the target needs before being destroyed")]
    [SerializeField] protected int requiredHits;
    public static event Action<int> TargetHit;
    public virtual void OnHit()
    {
        Debug.Log("I've been shot!");
        //Play a random sound

        TargetHit?.Invoke(targetScoreValue);

        requiredHits--;

        if(requiredHits <= 0)
        {
            DestroyTarget();
        }


    }

    public virtual void Update()
    {

    }

    public virtual void DestroyTarget()
    {
        //Destroy(gameObject);
    }
}
