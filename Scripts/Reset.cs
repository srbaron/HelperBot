using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
	Scene currentScene;
	string sceneName;

	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene (sceneName);
		}
	}
}
