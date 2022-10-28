using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    public AudioClip deathSFX;



    private AudioSource _audioSource;
    
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

        
    

    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSFX);
    }
}
