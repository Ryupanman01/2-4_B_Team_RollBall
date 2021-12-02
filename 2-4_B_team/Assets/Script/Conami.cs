using System;
using UnityEngine;

public class Conami : MonoBehaviour
{
    public GameObject ItemBox;
    int cmdSeq = 0;
    int[] keyCodes;
    int[] konamiCommand = new[] {
        (int)KeyCode.UpArrow,
        (int)KeyCode.UpArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.DownArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.LeftArrow,
        (int)KeyCode.RightArrow,
        (int)KeyCode.B,
        (int)KeyCode.A
    };
    int kcnt = 0;

    private void Start()
    {
        ItemBox.SetActive(true);
        keyCodes = (int[])Enum.GetValues(typeof(KeyCode));
    }

    void Update()
    {
        var len = keyCodes.Length;
        if (GameManager.countdown < 0f)
        {
            for (var i = 0; i < len; i++)
            {
                if (Input.GetKeyUp((KeyCode)keyCodes[i]))
                {
                    if (konamiCommand[cmdSeq] == keyCodes[i])
                    {
                        cmdSeq++;
                        if (cmdSeq == konamiCommand.Length)
                        {
                            kcnt++;
                            print("konami! " + kcnt);
                            PlayerController.score = 12;
                            ItemBox.SetActive(false);
                            cmdSeq = 0;
                        }
                    }
                    else
                    {
                        cmdSeq = 0;
                    }
                }
            }
        }
    }
}