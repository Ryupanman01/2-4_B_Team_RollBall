using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	private int select = 0;
	[SerializeField] GameObject SelectPanel;
	[SerializeField] GameObject Panel;
	// Use this for initialization
	void Start()
	{
		SelectPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.anyKeyDown)
		{
			if (select == 0)
			{
				Panel.SetActive(false);
				SelectPanel.SetActive(true);
			}
		}
	}
}