using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannyController : MonoBehaviour
{
    public float speed = 3;
    public float inspeed = 3;
    public float runspeed = 0.5f;
    public float rotationSpeed = 80;
    public float gravity = 100;
   // public float jumpspeed = 7;
    float rotation;
    float rotationX;
    float rotationY;
    Vector3 movedir = Vector3.zero;
    private Rigidbody rb;
    


    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        if (controller.isGrounded)
        {
           
            movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movedir = transform.TransformDirection(movedir);
            movedir *= speed;
            if (Input.GetKeyUp(KeyCode.LeftShift)) 
            {
                anim.SetInteger("run", 0);
               // speed = runspeed;
            }
            if (Input.GetKey(KeyCode.W))  // Move forward
            {
               

                if (Input.GetKey(KeyCode.LeftShift))  // Move forward RUN
                {
                    anim.SetInteger("run", 1);
                    anim.SetInteger("walk", 0);
                    speed = runspeed;
                }
                else
                {
                    anim.SetInteger("run", 0);
                    anim.SetInteger("walk", 1);
                 
                    speed = inspeed;

                }
              
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetInteger("walk", 0);
                    anim.SetInteger("jump", 1);
                    movedir.y = 4;
                }
                else
                {
                    anim.SetInteger("jump", 0);
                    anim.SetInteger("walk", 1);

                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("walk", 0);
                anim.SetInteger("run", 0);

            }
             if (Input.GetKey(KeyCode.S))  // Move backward
            {

                    if (Input.GetKey(KeyCode.LeftShift))  // Move backward RUN
                    {
                        anim.SetInteger("run", 1);               
                    }
                    else
                    {
                        anim.SetInteger("run", 0);
                        anim.SetInteger("walk", 1);
                    }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("walk", 0);
                anim.SetInteger("run", 0);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (anim.GetInteger("run") == 1)
                {
                    anim.SetInteger("run", 0);
                    anim.SetInteger("runjump", 1);
                    
                    movedir.y = 4.5f;
                }
                else 
                {
                    anim.SetInteger("jump", 1);
                    movedir.y = 4;
                }
                
            }
            else
            {
                anim.SetInteger("jump", 0);
                anim.SetInteger("runjump", 0);
                
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetInteger("run", 0);
                // speed = runspeed;
            }



        }




        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
    }
}
