﻿using UnityEngine;

public class FlipControlRight : MonoBehaviour
{
    private SoundController sound;
    public bool isKeyPress = false;
    public bool isTouched = false;

    public float speed = 0f;
    private HingeJoint2D hingeJoint2D;
    private JointMotor2D jointMotor;

    void Start()
    {
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
        hingeJoint2D = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint2D.motor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isKeyPress = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isKeyPress = false;
        }
    }

    void FixedUpdate()
    {
        // on press keyboard or touch Screen
        if (isKeyPress == true && isTouched == false || isKeyPress == false && isTouched == true)
        {
            sound.flipRgt.Play();
            jointMotor.motorSpeed = -speed;
            hingeJoint2D.motor = jointMotor;
        }
        else
        {
            // snap the motor back again
            jointMotor.motorSpeed = speed;
            hingeJoint2D.motor = jointMotor;
        }
    }
}