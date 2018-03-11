using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Script to handle user interaction

public class ButtonSctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        //method for restarting the current scene
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
        //method for quiting the application
        Application.Quit();
    }

}
