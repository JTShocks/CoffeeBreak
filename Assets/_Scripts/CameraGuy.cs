using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraGuy : Queuer
{

    [Header("Camera Guy Variables")]
    public bool isActivated;
    [SerializeField] List<Sprite> hurtSprites;

    [SerializeField] Transform popOutTransform;
    [SerializeField] List<AudioClip> voiceBarks;

    [SerializeField] float moveSpeed;
    [SerializeField] float flashDelay;
    
    [SerializeField] 
    [Range(0,1000)]
    int pointsToRemove;

    private int currentHitSprite = 0;


    //Camera guy functions

    //Shows up at a random point of the screen
    //Waits a few seconds to take your picture
        //If he succeeds, flashes your screen
            //lose points and slow down

    public override void Update()
    {
        if(isActivated)
        {
            transform.position = Vector3.MoveTowards(transform.position, popOutTransform.position, moveSpeed *Time.deltaTime);
            if(Vector3.Distance(transform.position, popOutTransform.position) < 0.1f)
            {
                //Flash the screen
                //play audio
                StartCoroutine(Flash());
                isActivated = false;
            }
        }
    }

    public override void OnHit()
    {
        spriteRenderer.sprite = hurtSprites[currentHitSprite];
        if(currentHitSprite == 0)
        {
            currentHitSprite = 1;
        }
        else
        {
            currentHitSprite = 0;
        }
        base.OnHit();

    }

    IEnumerator Flash()
    {
        //Play audio clip
        int rng = Random.Range(0, voiceBarks.Count);
        EventManager.OnPlaySoundEffect(voiceBarks[rng]);
        yield return new WaitForSeconds(flashDelay);
        //Run the camera flash event
        if(requiredHits <= 0)
        {
            yield break;
        }
        EventManager.OnScreenFlash();
        GameManager.Instance.LosePoints(pointsToRemove);
        //if it 
        Destroy(gameObject, .8f);
        yield return null;
    }
}
