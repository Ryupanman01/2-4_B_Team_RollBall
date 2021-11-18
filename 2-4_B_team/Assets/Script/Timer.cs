using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text CountDownText;  //カウントダウンテキスト
    public Text StartText;  //スタートテキスト

    //カウントダウン
    float countdown = 4.0f;
    int count;

    void Start()
    {
    }

    void Update()
    {
        //1秒以上なら
        if(countdown >= 1)
        {
            Application.targetFrameRate = 60;   //60Fpsにする
            Debug.Log("カウントダウンのFPS：" + Application.targetFrameRate);

            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountDownText.text = count.ToString();
            StartText.enabled = false;      //スタートテキストを非表示にする
        }
        //1秒より少ないなら
        if (countdown < 1 && countdown > -1)
        {
            Application.targetFrameRate = 30;   //30Fpsにする
            Debug.Log("スタートのFPS：" + Application.targetFrameRate);
            countdown -= Time.deltaTime;
            CountDownText.text = "";        //カウントダウンテキストを無にする
            StartText.enabled = true;       //スタートテキストを表示する
        }
        //0秒よりすくないなら
        if (countdown < 0)
        {
            StartText.enabled = false;  //スタートテキストを非表示にする
        }
    }
}
