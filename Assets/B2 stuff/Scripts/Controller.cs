using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotationSpeed = 80;
    public float gravity = 100;
    float rotationY;

    Vector3 movedir = Vector3.zero;

    public float speed = 1.5f;
    public float runspeed = 3;
    public Rigidbody rb;
    public CapsuleCollider cc;
    public float jumpForce = 7;
    
    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movedir = transform.TransformDirection(movedir);



            if (Input.GetKey(KeyCode.LeftShift))
            {


                transform.position += movedir * Time.deltaTime * runspeed;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetInteger("Jump", 1);
                    movedir.y = 4;
                }
                else
                {
                    anim.SetInteger("Jump", 0);
                }
            }
            else
            {
                transform.position += movedir * Time.deltaTime * speed;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetInteger("Jump", 1);
                    movedir.y = 4;
                }
                else
                {
                    anim.SetInteger("Jump", 0);
                }

            }
            
        }
        movedir.y -= gravity * Time.deltaTime * jumpForce;
        controller.Move(movedir * Time.deltaTime);

        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}