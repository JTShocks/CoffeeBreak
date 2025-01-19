using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Shortcut : Target
{

    [SerializeField] Animator animator;
    //Hold a spline for the new camera path
    [SerializeField] CinemachineDollyCart shortCutCart;
    [SerializeField] float cartStartPoint;

    public override void OnHit()
    {


        //Send an event to switch the camera spline
        EventManager.OnSwitchCart(shortCutCart, cartStartPoint);
        if(animator != null)
        {
            animator.SetTrigger("OpenShortcut");
        }

                base.OnHit();
    }
}
