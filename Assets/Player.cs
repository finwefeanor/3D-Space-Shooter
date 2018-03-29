using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float speed = 4.0f;
    [Tooltip("In m")] [SerializeField] float xPosLimit = 5.0f;
    [Tooltip("In m")] [SerializeField] float yPosLimit = 5.0f;

    [SerializeField] float posPitchFactor = -5.0f;
    [SerializeField] float posYawFactor = 5.0f;
    [SerializeField] float controlPitchFactor = -30.0f;
    [SerializeField] float controlRollFactor = -30.0f;

    float xOffset;
    float yOffset;

    float horizontalThrow, verticalThrow;

	// Use this for initialization
	void Start () {
        Debug.Log(Mathf.Clamp(10, 1, 9));
    }
	
	// Update is called once per frame
	void Update () 
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() 
    {
        float pitch = transform.localPosition.y * posPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x  * posYawFactor;
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation() {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        xOffset = horizontalThrow * speed * Time.deltaTime; //we determined how much meter / second the speed
        yOffset = verticalThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xPosLimit, xPosLimit);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yPosLimit, yPosLimit);

        transform.localPosition =
            new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
