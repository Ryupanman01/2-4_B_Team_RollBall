﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : PlayerController
{
    public int pause;
    public int MenuSelect = 0;
    [SerializeField] GameObject PausePanel;

    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;
    /*
    public Text textPause;
    public Text textReStart;
    public Text textTitleBack;
    public Text textGameEnd;
    */

    //カウントダウン
    float countdown = 4.0f;

    void Start()
    {
        PausePanel.SetActive(false);
        /*
        textPause.enabled = false;
        textReStart.enabled = false;
        textTitleBack.enabled = false;
        textGameEnd.enabled = false;
*/
        pause = 0;
    }

    /*
    IEnumerator ReStart()
    {
        //　3秒後にリスタート
        yield return new WaitForSeconds(3f);
        //　現在のシーンを再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */

    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            if(score < 12) {
                if (Input.GetKeyDown("joystick button 7"))
                {
                    if (pause == 0)
                    {
                        PausePanel.SetActive(true);
                        pause = 1;

                        Time.timeScale = 0f;

                    }
                    else
                    {
                        PausePanel.SetActive(false);
                        pause = 0;
                        Time.timeScale = 1f;
                    }
                }
                else
                {
                    ;
                }
            }
        }
    }
}

