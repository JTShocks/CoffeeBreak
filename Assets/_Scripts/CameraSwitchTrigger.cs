using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
   [SerializeField] CinemachineVirtualCamera newCamera;

   void OnTriggerEnter(Collider collider)
   {
        PlayerController player = collider.GetComponent<PlayerController>();
        if(player != null)
        {
            EventManager.OnSwitchCamera(newCamera);
        }

   }
}
