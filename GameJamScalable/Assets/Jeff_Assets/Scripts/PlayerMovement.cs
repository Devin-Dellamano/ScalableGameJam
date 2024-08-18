using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody rb;
    Vector3 goDirection;
    public Transform orientation;
    public float horizantalInput = 0f;
    public float verticalInput = 0f;
    public float playSpeed = 5f;
    public float groundDrag;
    public float jumpForce;
    public float jumpCoolDown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("KeyBind")]
    public KeyCode jumpKey = KeyCode.Space;




    [Header("GroundCheck")]
    public LayerMask whatIsGround;
    public float playerHeight;
    public bool onGround = true;


    // Start is called before the first frame update
    private void Start()
    {
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
            rb.drag = 0;
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
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision){
        // tag all things we run on as terrain
        if(collision.gameObject.tag == "Terrain"){
            onGround = true;
        }
    }

    private void ResetJump(){
        readyToJump = true;
    }
}
