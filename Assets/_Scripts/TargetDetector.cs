using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{

    void OnTriggerStay(Collider collider)
    {
        Target target = collider.GetComponent<Target>();
        if(target != null)
        {

        }
    }
}
