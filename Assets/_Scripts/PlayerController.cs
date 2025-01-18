using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    //how far the player can shoot
    [Tooltip("How far the player can smack things from")]
    public float rayLength;
    public LayerMask canBeHit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Shoot();
        }
    }

    void Shoot()
    {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, canBeHit))
            {

            }
    }
}
