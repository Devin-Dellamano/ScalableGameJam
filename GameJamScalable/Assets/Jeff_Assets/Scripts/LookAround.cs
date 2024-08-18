using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;
    public float minYAngle = -90f; // Minimum Y-axis rotation angle
    public float maxYAngle = 90f;  // Maximum Y-axis rotation angle

    void Update()
    {
        //rotationY += Input.GetAxis("Mouse X") * sensitivity;
       //rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        // Clamp the rotationX to limit the Y-axis rotation
        //rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);

       // transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }

}
