using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	//パネル
	[SerializeField] GameObject SelectPanel;
	[SerializeField] GameObject TitlePanel;

	//BGM
	public AudioSource TitleBGM;
	private bool titlebgm_flg;
	public AudioSource CursorCheck;


	void Start()
	{
		SelectPanel.SetActive(false);
		titlebgm_flg = true;
	}

	void Update()
	{
		if(titlebgm_flg == true)
        {
			TitleBGM.Play();
			titlebgm_flg = false;
        }
		if(Input.GetKeyDown("joystick button 1"))
		{
			CursorCheck.Play();
			Debug.Log("音を鳴らしたよ");
			TitlePanel.SetActive(false);
			SelectPanel.SetActive(true);
			TitleBGM.Stop();
		}
	}
}