using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirtsPerson_Controler : MonoBehaviour
{
    CharacterController controller;
    public Transform fpsCamera;
    
    public float sensitivy = 200f;
    public float speed = 15f;

    float xRotation = 0f;

    bool isGrounded;
    public Transform groundSensor;
    public float sensorRadius;
    public LayerMask ground;
    public float gravity = -9.81f;
    public float jumpHeight = 1f;
    Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivy * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        // este no funciona fpsCamera.rotation = Quaternion.Euler(mouseY, 0, 0);
        fpsCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

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
        void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 8)
        {
            
            GameManager.Instance.Choque();
        }
    }
}
