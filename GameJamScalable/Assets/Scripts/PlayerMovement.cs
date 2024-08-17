using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float horizantalInput = 0f;
    public float verticalInput = 0f;
    public bool onGround = true;
    public float playSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizantalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * playSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizantalInput * playSpeed);

        if(Input.GetButtonDown("Jump") && onGround){
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        }
    }


    private void OnCollisionEnter(Collision collision){
        // tag all things we run on as terrain
        if(collision.gameObject.tag == "Terrain"){
            onGround = true;
        }
    }
}
