using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGuyTrigger : MonoBehaviour
{

    [SerializeField] CameraGuy guy;
    void OnTriggerEnter(Collider collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();
        if(player != null)
        {
            guy.isActivated = true;
        }
    }
}
