using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToBody : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Transform player;
    public Transform orientation;
    public float rotationSpeed;
    public Transform gameObj;

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = playerDir.normalized;

        // rotate player
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if( inputDir != Vector3.zero ){
            gameObj.forward = Vector3.Slerp(gameObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}
