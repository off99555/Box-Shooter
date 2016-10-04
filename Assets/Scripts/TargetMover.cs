using System;
using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour
{
    // define the possible states through an enumeration
    public enum MotionDirections
    {
        Spin,
        Horizontal,
        Vertical
    };

    // store the state
    public MotionDirections MotionState = MotionDirections.Horizontal;

    // motion parameters
    public float SpinSpeed = 180.0f;
    public float MotionMagnitude = 2.0f;
    [Tooltip("Rounds to move in a second")]
    public float Frequency = 0.5f;

    public float TwoPiFrequency
    {
        get { return 2*Mathf.PI*Frequency; }
    }

    // Update is called once per frame
    void Update()
    {
        // do the appropriate motion based on the motionState

        float distance = 0;
        if (MotionState != MotionDirections.Spin)
        {
            // derivative of sine wave with respect to time a.k.a. d/dx of sin(fx)
            var derivSin = Mathf.Cos(TwoPiFrequency*Time.timeSinceLevelLoad)*TwoPiFrequency;
            var dsin = derivSin*Time.deltaTime; // the integral
            distance = dsin*MotionMagnitude;
        }
        switch (MotionState)
        {
            case MotionDirections.Spin:
                // rotate around the up axix of the gameObject
                transform.Rotate(Vector3.up*SpinSpeed*Time.deltaTime);
                break;
            case MotionDirections.Horizontal:
                // move up and down over time
                transform.Translate(Vector3.right*distance);
                break;
            case MotionDirections.Vertical:
                // move up and down over time
                transform.Translate(Vector3.up*distance);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}