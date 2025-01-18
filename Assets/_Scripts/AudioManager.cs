using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource source;
    // Start is called before the first frame update
    void OnEnable()
    {
        EventManager.PlaySoundEffect += PlaySoundEffect;
    }

    // Update is called once per frame
    void OnDisable()
    {
        EventManager.PlaySoundEffect -= PlaySoundEffect;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void PlaySoundEffect(AudioClip audioClip)
    {
        source.PlayOneShot(audioClip);
    }
}
