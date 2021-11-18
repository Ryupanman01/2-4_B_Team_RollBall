using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int pause;
    private int MenuSelect = 0;
    [SerializeField] GameObject PausePanel;

    //カウントダウン
    float countdown = 4.0f;

    void Start()
    {
        PausePanel.SetActive(false);
        pause = 0;
    }

    void Update()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            if(PlayerController.score < 12) {
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

