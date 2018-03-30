using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In Seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    // Use this for initialization
    void Start() 
    {
        deathFX.SetActive(false);       
    }

    void OnTriggerEnter(Collider other) 
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("LoadSameLevel", levelLoadDelay);
    }

    private void StartDeathSequence() 
    {
        print("You are dead. Controls are disabled");
        gameObject.SendMessage("OnPlayerDeath");
    }

    void LoadSameLevel() //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
