using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 28f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;

    //[SerializeField] float positionPitchFactor = 0f;
    [SerializeField] float positionYawFactor = 0.8f;
    [SerializeField] float controlYawFactor = 14f;
    [SerializeField] float positionRollFactor = -0.2f;
    [SerializeField] float controlRollFactor = -5f;
    [SerializeField] GameObject boatTrails;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        float yawDueToPosition = positionYawFactor * transform.localPosition.x + 90;
        float yawDueToControl = controlYawFactor * xThrow;
        float rollDueToPosition = positionRollFactor * transform.localPosition.x;
        float rollDueToControl = controlRollFactor * xThrow;
        float pitch = 0f;
        float yaw = yawDueToPosition + yawDueToControl;
        float roll = rollDueToPosition + rollDueToControl;
        transform.localRotation = Quaternion.Euler(roll, yaw, pitch);
        boatTrails.transform.localRotation = Quaternion.Euler(0, 90, -roll);
        
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xSpeed * xThrow * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }
}
