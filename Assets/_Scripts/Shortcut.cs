using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Shortcut : Target
{
    //Hold a spline for the new camera path

    [SerializeField] CinemachineVirtualCamera shortCutCamera;

    public override void OnHit()
    {
        base.OnHit();

        //Send an event to switch the camera spline
    }
}
