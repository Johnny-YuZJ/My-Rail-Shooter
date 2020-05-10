using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BoatTrailParticles : MonoBehaviour {

    [SerializeField] float positionRollFactor = 0.4f;
    [SerializeField] float controlRollFactor = 5;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ProcessRotation();
    }

    private void ProcessRotation() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float rollDueToPosition = positionRollFactor * transform.localPosition.x;
        float rollDueToControl = controlRollFactor * xThrow;
        float roll = rollDueToPosition + rollDueToControl;
        transform.localRotation = Quaternion.Euler(0, 90, roll);
    }
}
