using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class VRSimple : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 8f;

    Vector3 acceleration = Vector3.zero;
    float heading = 0f;
    KalmanFilterFloat kmf;
    float yVelocity = 0;
    public TrackedPoseDriver component;
    bool giro = false;
    public GameObject warning;
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            giro = true;
            component.enabled = true;
            if(warning)
            warning.SetActive(false);
        }
        else { 
            //kmf = new KalmanFilterFloat();
            Input.compass.enabled = true;
            Input.location.Start();
        }
    }

    void Update()
    {
#if (UNITY_EDITOR)
        return;
#endif
        if (!giro)
        {
            SetAcceleration();
            SetCompassHeading();

            transform.eulerAngles = SetRotation();
        }
    }

    void SetAcceleration()
    {
        Vector3 _acceleration = Input.acceleration;

        acceleration.x = Mathf.Lerp(acceleration.x, _acceleration.x, Time.deltaTime * rotationSpeed);
        acceleration.y = Mathf.Lerp(acceleration.y, _acceleration.y, Time.deltaTime * rotationSpeed);
        acceleration.z = Mathf.Lerp(acceleration.z, _acceleration.z, Time.deltaTime * rotationSpeed);
    }

    void SetCompassHeading()
    {
        float _heading = Input.compass.trueHeading;
        //heading=kmf.Update(_heading,null,null);
        heading = Mathf.LerpAngle(heading, _heading, Time.deltaTime * rotationSpeed);
        //heading = Mathf.SmoothDampAngle(heading, _heading,ref yVelocity, rotationSpeed,120, Time.deltaTime);
    }

    Vector3 SetRotation()
    {
        float _rotationX = Mathf.Atan2(acceleration.z, acceleration.y);
        float _magnitudeYZ = Mathf.Sqrt(Mathf.Pow(acceleration.y, 2) + Mathf.Pow(acceleration.z, 2));
        float _rotationZ = Mathf.Atan2(acceleration.x, _magnitudeYZ);

        float _angleX = _rotationX * (180f / Mathf.PI) + 180f;
        float _angleZ = -_rotationZ * (180f / Mathf.PI);

        return   new Vector3(_angleX, -(_angleZ - heading), 0f);
    }
}
