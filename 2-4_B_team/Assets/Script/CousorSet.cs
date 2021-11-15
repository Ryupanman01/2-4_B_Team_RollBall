using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CousorSet : MonoBehaviour
{
    int Pos = 1;
    public int nummenu;
    public float linewidth;

    //SE
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    float lastTimeStickDown_ = 0f;

    // Use this for initialization
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime - lastTimeStickDown_ > 0.25f)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            //if (Input.GetKeyDown("down") && Pos != nummenu)
            if (Input.GetAxisRaw("Vertical") < 0 && Pos != nummenu)
            {
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
                Vector3 tmp = this.transform.position;
                this.transform.position = new Vector3(tmp.x, tmp.y - linewidth, tmp.z);
                Pos += 1;
                lastTimeStickDown_ = Time.unscaledTime;
            }
            else if (Input.GetAxisRaw("Vertical") > 0 && Pos != 1)
            {
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
                Vector3 tmp = this.transform.position;
                this.transform.position = new Vector3(tmp.x, tmp.y + linewidth, tmp.z);
                Pos -= 1;
                lastTimeStickDown_ = Time.unscaledTime;
            }
            else if (Input.GetKeyDown("joystick button 1"))
            {
                Debug.Log("音を鳴らしたよ");
                audioSource.PlayOneShot(sound2);
                function();
            }
        }
    }
    void function()
    {
        if (Pos == 1)
        {
            
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        else if (Pos == 2)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("TitleScene");
        }
        else if (Pos == 3)
        {
            Quit();
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
}