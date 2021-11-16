using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_se : MonoBehaviour
{
    private Rigidbody rb;
    AudioSource audioSource;
    public AudioClip sound;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if(rb.velocity.magnitude > 0.1f)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);
            }
        }
    }
}
