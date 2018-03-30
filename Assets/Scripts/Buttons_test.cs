using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_test : MonoBehaviour {

    public GameObject GO;

    void OnGUI() {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Enable")) //creates gui button 
        {
            Debug.Log("Enable: " + GO.name);
            GO.SetActive(true);
        }
        if (GUI.Button(new Rect(10, 50, 100, 30), "Disable"))
        {
            Debug.Log("Disable: " + GO.name);
            GO.SetActive(false);
        }
    }
}
