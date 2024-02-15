using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audio : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
}
