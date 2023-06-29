using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.1f;
    public float SpeedRotate = 0.1f;
    public Transform cameraTransform;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //  transform.position = new Vector3(10,4,10);
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        rb.MovePosition(rb.position + (transform.forward * inputVertical + transform.right * inputHorizontal) * Speed * Time.deltaTime);
        
        transform.Rotate(0, inputMouseX * SpeedRotate, 0);
        cameraTransform.Rotate(-inputMouseY * SpeedRotate, 0, 0);

    }
}
