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
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //if (Input.GetKeyDown("down") && Pos != nummenu)
        if (Input.GetAxisRaw("Vertical") < 0 && Pos != nummenu)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y - linewidth, tmp.z);
            Pos += 1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && Pos != 1)
        {
            Vector3 tmp = this.transform.position;
            this.transform.position = new Vector3(tmp.x, tmp.y + linewidth, tmp.z);
            Pos -= 1;
        }
        else if (Input.GetKeyDown("joystick button 1"))
        {
            function();
        }
    }
    void function()
    {
        if (Pos == 1)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
        else if (Pos == 2)
        {

        }
        else if(Pos == 3)
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