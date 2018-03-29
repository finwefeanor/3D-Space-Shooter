using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    // Use this for initialization
    void Start() 
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        StartDeathSequence();
    }

    private void StartDeathSequence() 
    {
        print("You are dead. Controls are disabled");
        gameObject.SendMessage("OnPlayerDeath");
    }
}
