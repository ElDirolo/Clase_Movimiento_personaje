using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler_Player : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Transform groundSensor;
    public LayerMask ground;
    public float sensorRadius = 0.1f;

    public float speed = 5;
    public float jumpForce = 20;
    public float jumpHeight = 1;
    private float gravity = -9.81f;
    public bool isGrounded;

    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(move != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            
            controller.Move(move * speed * Time.deltaTime);

        }
        
        Jump();

    }


    void Jump()
    {
        //isGrounded = controller.isGrounded;
        isGrounded = Physics.CheckSphere(groundSensor.position, sensorRadius, ground);
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //playerVelocity.y += jumpForce;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
