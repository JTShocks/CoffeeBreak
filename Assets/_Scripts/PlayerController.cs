using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{


    Animator handsAnimator;
    enum Hands{
        Left = -1,
        Right = 1
    }

    float handToUse = 1;

    //how far the player can shoot
    [Tooltip("How far the player can smack things from")]
    public float rayLength;
    public LayerMask canBeHit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            handToUse = Random.Range(-1, 1);

            if(handToUse < 0)
            {
                Shoot(Hands.Left);
            }
            else
            {
                Shoot(Hands.Right);
            }

        }
    }

    void Shoot(Hands hand)
    {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, canBeHit))
            {
                Debug.Log(hit.collider.name);

                //Check if the object is a valid target
                //If yes, trigger the target

                Target target = hit.collider.GetComponent<Target>();
                if(target != null)
                {
                    target.OnHit();
                }
            }
    }
}

