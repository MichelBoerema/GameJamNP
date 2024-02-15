using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour
{
    [SerializeField] AudioSource boxAudio;
    private void OnCollisionEnter(Collision collision)
    {
        boxAudio.Play();
    }
}
