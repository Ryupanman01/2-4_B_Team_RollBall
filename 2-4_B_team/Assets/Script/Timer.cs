using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text CountDownText;  //カウントダウンテキスト
    public Text StartText;  //スタートテキスト

    float countdown = 4.0f;
    int count;

    public AudioClip sound1;     //カウントダウンのSE
    AudioSource audioSource;    //カウントダウンのSE


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  //SE
    }

    private void Update()
    {

        //1秒以上なら
        if (countdown >= 1)
        {
            Application.targetFrameRate = 60;   //60Fpsにする
            Debug.Log("カウントダウンのFPS：" + Application.targetFrameRate);

            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountDownText.text = count.ToString();

            if (CountDownText.enabled)  //一回だけ音を鳴らす
            {
                audioSource.PlayOneShot(sound1);//SEを鳴らす
            }


            StartText.enabled = false;      //スタートテキストを非表示にする
        }
        //1秒より少ないなら
        if (countdown < 1 && countdown > -1)
        {
            Application.targetFrameRate = 30;   //30Fpsにする
            Debug.Log("スタートのFPS：" + Application.targetFrameRate);
            countdown -= Time.deltaTime;
            //CountDownText.text = "";        //カウントダウンテキストを無にする
            CountDownText.enabled = false;
            StartText.enabled = true;       //スタートテキストを表示する
        }
        //0秒よりすくないなら
        if (countdown < 0)
        {
            StartText.enabled = false;  //スタートテキストを非表示にする
        }
    }
}
