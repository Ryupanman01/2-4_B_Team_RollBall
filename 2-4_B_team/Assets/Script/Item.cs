using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip sound;

    void Update()
    {
        if (gameObject.CompareTag("Item"))
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        else if (gameObject.CompareTag("Item1"))
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
