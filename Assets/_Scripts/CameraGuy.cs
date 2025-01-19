using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGuy : Queuer
{

    [Header("Camera Guy Variables")]
    public bool isActivated;
    [SerializeField] List<Sprite> hurtSprites;

    [SerializeField] Transform popOutTransform;

    [SerializeField] float moveSpeed;
    [SerializeField] float flashDelay;
    
    [SerializeField] 
    [Range(0,1000)]
    float pointsToRemove;


    //Camera guy functions

    //Shows up at a random point of the screen
    //Waits a few seconds to take your picture
        //If he succeeds, flashes your screen
            //lose points and slow down

    void Update()
    {
        if(isActivated)
        {
            transform.position = Vector3.MoveTowards(transform.position, popOutTransform.position, moveSpeed *Time.deltaTime);
            if(Vector3.Distance(transform.position, popOutTransform.position) < 0.1f);
            {
                //Flash the screen
                //play audio
                StartCoroutine(Flash());
                isActivated = false;
            }
        }
    }

    IEnumerator Flash()
    {
        //Play audio clip
        yield return new WaitForSeconds(flashDelay);
        //Run the camera flash event
        EventManager.OnScreenFlash();
        //if it 

        yield return null;
    }
}
