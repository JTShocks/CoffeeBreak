using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CinemachineDollyCart currentCart;

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



    void OnEnable()
    {
        EventManager.SwitchCart += SwitchCart;
    }

    void OnDisable()
    {
        EventManager.SwitchCart -= SwitchCart;
    }
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

    public void StopCart()
    {
        currentCart.m_Speed = 0;

    }

    public void SwitchCart(CinemachineDollyCart newCart)
    {
        CinemachineDollyCart previous = currentCart;
        currentCart = newCart;
        currentCart.gameObject.SetActive(true);
        previous.gameObject.SetActive(false);

    }
}

