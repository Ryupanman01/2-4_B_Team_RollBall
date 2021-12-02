using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cursortest : MonoBehaviour
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
            pos.y += 60;
            if (number < 0)
            {
                number = 2;
                pos.y -= 3 * 60;
            }
        }
        if (0 > Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            CursorMove.Play();
            number++;
            pos.y -= 60;
            if (number > 2)
            {
                number = 0;
                pos.y += 3 * 60;
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
            Scene scene = SceneManager.GetActiveScene();
            int buildIndex = scene.buildIndex;
            SceneManager.LoadScene(buildIndex);
            Time.timeScale = 1f;
        }
        else if (number == 1)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("TitleScene");
        }
        else if (number == 2)
        {
            Quit();
        }
    }

    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
             UnityEngine.Application.Quit();
        #endif
    }
}