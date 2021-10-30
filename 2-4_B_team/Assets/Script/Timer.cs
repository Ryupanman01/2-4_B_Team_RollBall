using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text CountDownText;

    float countdown = 4.0f;
    int count;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(countdown >= 1)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountDownText.text = count.ToString();
        }
        if(countdown < 1)
        {
            CountDownText.text = "";
        }
    }
}
