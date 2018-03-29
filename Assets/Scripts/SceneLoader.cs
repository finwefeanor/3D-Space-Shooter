using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    void Start() {
        Invoke("LoadSplashLevel", 2f);
    }

    void LoadSplashLevel() {
        SceneManager.LoadScene(1);
    }
}
