using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smok_Flag : MonoBehaviour
{
    private ParticleSystem ps;
    public bool moduleEnabled;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        ParticleSystem.EmissionModule emission = ps.emission;
        moduleEnabled = false;
        emission.enabled = moduleEnabled;

        Invoke("Call", 4.5f);
    }
    void Call()
    {
        ParticleSystem.EmissionModule emission = ps.emission;
        if (moduleEnabled)
        {
            moduleEnabled = false;
        }
        else
        {
            moduleEnabled = true;
        }
        emission.enabled = moduleEnabled;
    }
}
