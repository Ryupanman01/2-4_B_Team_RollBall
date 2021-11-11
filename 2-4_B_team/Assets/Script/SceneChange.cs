using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2"))
		{
			SceneManager.LoadScene("SampleScene");
		}
	}
}