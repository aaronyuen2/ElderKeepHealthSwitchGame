using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    float speed = 10.0f;
    public float x, y, z;

    // low pass filter
    float AccelerometerUpdateInterval = 1.0f / 60.0f;
    float LowPassKernelWidthInSeconds = 1.0f;

    private float LowPassFilterFactor;
    private Vector3 lowPassValue = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds; // tweakable
        lowPassValue = Input.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;

        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis
        //   dir.x = -Input.acceleration.y;
        //    dir.z = Input.acceleration.x;

        dir = LowPassFilterAccelerometer();

        print(dir);

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        print(dir);

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        //transform.Translate(dir * speed);

        x = dir.x; // Input.acceleration.x;
        y = dir.y; // Input.acceleration.y;
        z = dir.z; // Input.acceleration.z;
    }

    Vector3 LowPassFilterAccelerometer() {
        lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
        return lowPassValue;
    }
}
