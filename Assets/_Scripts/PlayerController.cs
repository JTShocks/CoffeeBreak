using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] int playerMoveSpeed;

    private float currentMoveSpeed;
    public CinemachineDollyCart currentCart;


    bool playerIsStopped;

    [Range(0, 1)]
    [SerializeField] float slowdownDebuff;

    [SerializeField] Animator handsAnimator;
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
        EventManager.ScreenFlash += FlashDebuff;
    }



    void OnDisable()
    {
        EventManager.SwitchCart -= SwitchCart;
        EventManager.ScreenFlash -= FlashDebuff;
    }

    void Awake()
    {
        currentMoveSpeed = playerMoveSpeed;
    }
    // Update is called once per frame
    void Update()
    {

        handsAnimator.SetBool("playerIsStopped", playerIsStopped);
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

    void FixedUpdate()
    {
        CheckForTargets();
    }

    private void FlashDebuff()
    {
        StartCoroutine(SlowDown());
    }

    IEnumerator SlowDown()
    {
        currentMoveSpeed = playerMoveSpeed * slowdownDebuff;
        currentCart.m_Speed = currentMoveSpeed;
        yield return new WaitForSeconds(4);
        currentMoveSpeed = playerMoveSpeed;
        currentCart.m_Speed = currentMoveSpeed;
        yield return null;
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

                    Shortcut shortcut = target.GetComponent<Shortcut>();
                    if(shortcut!=null)
                    {
                        handsAnimator.Play("Push");
                    }
                    target.OnHit();
                    if(hand == Hands.Right)
                    {
                        float rng = Random.Range(0, 1);
                        if(rng > .5){
                            handsAnimator.Play("Uppercut");
                        }
                        else
                        {
                        handsAnimator.Play("Swipe");
                        }

                        
                    }
                    else
                    {
                        handsAnimator.Play("Left_Swipe");
                    }

                }
            }
    }

    public void StopCart()
    {
        currentCart.m_Speed = 0;
        playerIsStopped = true;

    }

    public void SwitchCart(CinemachineDollyCart newCart, float cartStartPoint)
    {
        CinemachineDollyCart previous = currentCart;
        currentCart = newCart;
        currentCart.gameObject.SetActive(true);
        previous.gameObject.SetActive(false);
        currentCart.m_Position = cartStartPoint;
        currentCart.m_Speed = playerMoveSpeed;

    }

    void CheckForTargets()
    {
        RaycastHit target;
        if(Physics.Raycast(transform.position, transform.forward, out target, 1, canBeHit))
        {
            StopCart();
        }
        else if(playerIsStopped)
        {
            currentCart.m_Speed = currentMoveSpeed;
            playerIsStopped = false;
        }
    }
}

