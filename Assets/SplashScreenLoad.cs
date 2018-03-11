using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //SceneManager.LoadScene(0);
        Invoke("LoadSplashLevel", 2f);
    }
	
    void LoadSplashLevel()
    {
        SceneManager.LoadScene(1);
    }
}
