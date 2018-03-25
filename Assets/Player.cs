using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] float xSpeed = 4.0f;
    float xOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        print(xOffset);
        //print(horizontalThrow);
	}
}
