using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
