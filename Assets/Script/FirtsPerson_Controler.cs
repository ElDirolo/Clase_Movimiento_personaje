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
        
    }
}
