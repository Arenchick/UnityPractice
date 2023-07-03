using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.1f;
    public float SpeedRotate = 0.1f;
    public float jumpForce = 100;
    public Transform cameraTransform;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //  transform.position = new Vector3(10,4,10);
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        float inputMouseX = Input.GetAxis("Mouse X");
        float inputMouseY = Input.GetAxis("Mouse Y");

        rb.MovePosition(rb.position + (transform.forward * inputVertical + transform.right * inputHorizontal) * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        transform.Rotate(0, inputMouseX * SpeedRotate * Time.deltaTime, 0);
        cameraTransform.Rotate(-inputMouseY * SpeedRotate * Time.deltaTime, 0, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
