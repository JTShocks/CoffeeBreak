using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{

    public Transform lookAtPosition;
   [SerializeField] CinemachineVirtualCamera newCamera;

   void OnTriggerEnter(Collider collider)
   {
        PlayerController player = collider.GetComponent<PlayerController>();
        if(player != null)
        {
            Debug.Log("Player is in range");
            //EventManager.OnSwitchCamera(newCamera);
            CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
            CinemachineVirtualCamera camera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();

            camera.m_LookAt = lookAtPosition;
        }
   }

   void OnTriggerExit(Collider collider)
   {
            CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
            CinemachineVirtualCamera camera = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();

            camera.m_LookAt = null;
            camera.transform.rotation = Quaternion.Euler(Vector3.zero); 
   }
}
