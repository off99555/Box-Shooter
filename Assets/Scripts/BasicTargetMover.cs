using System;
using UnityEngine;
using System.Collections;

public class BasicTargetMover : MonoBehaviour
{
    public float SpinSpeed = 180.0f;
    public float MotionMagnitude = 1.5f;

    // Update is called once per frame
    private void Update()
    {
        if (!Mathf.Approximately(SpinSpeed, 0))
        {
            transform.Rotate(Vector3.up, SpinSpeed*Time.deltaTime);
        }
        if (!Mathf.Approximately(MotionMagnitude, 0))
        {
            // we are going to move by mimicking the sine wave of time
            var cos = Mathf.Cos(Time.timeSinceLevelLoad); // derivative of sine with respect to time AKA slope
            var dy = cos*Time.deltaTime; // approximate the distance to move
            transform.Translate(Vector3.up*MotionMagnitude*dy);
        }
    }
}