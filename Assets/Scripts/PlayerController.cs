using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // todo work-out starting speed of playership

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 4.0f;
    [Tooltip("In m")] [SerializeField] float xPosLimit = 5.0f;
    [Tooltip("In m")] [SerializeField] float yPosLimit = 5.0f;

    [Header("Screen-position Based")]
    [SerializeField] float posPitchFactor = -5.0f;
    [SerializeField] float posYawFactor = 5.0f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -30.0f;
    [SerializeField] float controlRollFactor = -30.0f;

    float xOffset;
    float yOffset;

    float horizontalThrow, verticalThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update () 
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void OnPlayerDeath() // string referenced
    {
        isControlEnabled = false;
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

        xOffset = horizontalThrow * controlSpeed * Time.deltaTime; //we determined how much meter / second the speed
        yOffset = verticalThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xPosLimit, xPosLimit);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yPosLimit, yPosLimit);

        transform.localPosition =
            new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
