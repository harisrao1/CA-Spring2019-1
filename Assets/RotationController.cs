using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float rotationSpeed = 80;
    public float gravity = 100;
    float rotationY;

    Vector3 movedir = Vector3.zero;

    public float speed = 3;

    CharacterController controller;
    //Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movedir = transform.TransformDirection(movedir);
            movedir *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space");
                movedir.y = 40;
            }
        }

        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}