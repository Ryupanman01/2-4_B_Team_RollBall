
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    int number = 0;
    private float Trigger;
    public AudioSource CursorCheck;
    public AudioSource CursorMove;

    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;

        if (0 < Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            CursorMove.Play();
            number--;
            pos.y += 50;
            if (number < 0)
            {
                number = 3;
                pos.y -= 4 * 50;
            }
        }
        if (0 > Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            CursorMove.Play();
            number++;
            pos.y -= 50;
            if (number > 3)
            {
                number = 0;
                pos.y += 4 * 50;
            }
        }

        myTransform.position = pos;  // 座標を設定
        Trigger = Input.GetAxisRaw("Vertical"); //カーソルの移動速度制御

        if (Input.GetKeyDown("joystick button 1"))
        {
            CursorCheck.Play();
            Debug.Log("音を鳴らしたよ");
            Function();
        }
    }


    void Function()
    {
        if (number == 0)
        {

            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        else if (number == 1)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(2);
        }
        else if (number == 2)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(3);
        }
        else if (number == 3)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(4);
        }


    }
}