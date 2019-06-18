using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

    [SerializeField]float xSpeed = 10f;
	[Tooltip("in m")][SerializeField] float minXRange = -0.3f;
	[Tooltip("in m")][SerializeField] float maxXRange = 7f;
    [SerializeField]float ySpeed = 10f;
    [Tooltip("in m")] [SerializeField] float minyRange = -0.3f;
    [Tooltip("in m")] [SerializeField] float maxyRange = 7f;
    [SerializeField] float posPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float posYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;


    float xthrow, ythrow;
    bool isControlEnabled = true;

    // Use this for initialization
    void Start () {
		
		
	}
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
   
    // Update is called once per frame
    void Update ()
    {
        if (isControlEnabled == true)
        {
            HorizontalMotion();
            VerticalMotion();

            ProcessRotation();
        }

    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * posPitchFactor + ythrow * controlPitchFactor;
        float yaw = transform.localPosition.x * posYawFactor;
        float roll = xthrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw , roll);
    }

    private void VerticalMotion()
    {
        
        ythrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yoffsetThisFrame = ySpeed * ythrow * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yoffsetThisFrame;
        float clampedYpos = Mathf.Clamp(rawYPos, minyRange, maxyRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYpos, transform.localPosition.z);
    }

    private void HorizontalMotion()
    {
        xthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xoffsetThisFrame = xSpeed * xthrow * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xoffsetThisFrame;
        float clampedXpos = Mathf.Clamp(rawXPos, minXRange, maxXRange);
        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
    }
}
