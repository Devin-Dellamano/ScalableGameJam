using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Scale_Me scaler;
    private bool canScaleH = true;
    private bool canScaleV = true;

    [Header("Movement")]
    public Rigidbody rb;
    Vector3 goDirection;
    public Transform orientation;
    public float horizantalInput = 0f;
    public float verticalInput = 0f;
    public float playSpeed = 5f;
    public float groundDrag;
    public float jumpForce = 15f;
    public float jumpCoolDown;
    public float airMultiplier;
    public bool Kill = false;
    public bool Win = false;
    public bool NoScale = false;
    bool readyToJump = true;

    [Header("KeyBind")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode horizontalScale = KeyCode.LeftShift;
    public KeyCode verticalScale = KeyCode.LeftControl;

    [Header("GroundCheck")]
    public LayerMask whatIsGround;
    public float playerHeight;
    public bool onGround = true;
    public static bool isScaledV = false;
    public static bool isScaledH = false;


    // Start is called before the first frame update
    private void Start()
    {
        jumpForce = 15f;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();
        SpeedControl();
        if(onGround){
            rb.drag = groundDrag;
        }
        else{
            if(isScaledH && rb.velocity.y < 0){
                rb.drag = 3f;
            }
            else if(isScaledV && rb.velocity.y < 0){
                rb.drag = -4f;
            }
            else{
                rb.drag = 0;
            }
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput()
    {
        horizantalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(onGround && readyToJump && Input.GetKey(jumpKey)){
            readyToJump = false;

            Jump();
            onGround = false;

            Invoke(nameof(ResetJump), jumpCoolDown);
        }

        if(Input.GetKeyDown(horizontalScale) && canScaleH && !NoScale)
        {
            scaler.OnScaleH();
            canScaleH = false;
        }
        if(Input.GetKeyUp(horizontalScale) && canScaleH != true ){
            canScaleH = true;
        }
        
        if(Input.GetKeyDown(verticalScale) && canScaleV && !NoScale)
        {
            scaler.OnScaleV();
            canScaleV = false;
        }
        if(Input.GetKeyUp(verticalScale) && canScaleV != true){
            canScaleV = true;
        }
    }

    private void MovePlayer()
    {
        goDirection = orientation.forward * verticalInput + orientation.right * horizantalInput; 

        if(onGround){
            rb.AddForce(goDirection.normalized * playSpeed * 10f , ForceMode.Force);
        }
        else if(!onGround){
            rb.AddForce(goDirection.normalized * playSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl(){
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity
        if(flatVelocity.magnitude > playSpeed){
            Vector3 limitVel = flatVelocity.normalized * playSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
        
    }
    

    private void Jump(){
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision){
        // tag all things we run on as terrain
        if(collision.gameObject.tag == "Terrain"){
            onGround = true;
            rb.drag = 0;
        }
    }

    private void ResetJump(){
        readyToJump = true;
    }
}
