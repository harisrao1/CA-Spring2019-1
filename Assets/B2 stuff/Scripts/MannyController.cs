using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannyController : MonoBehaviour
{
    public float speed = 4;
    public float runspeed = 8;
    public float rotationSpeed = 80;
    public float gravity = 8;
    float rotation;
    float rotationX;
    float rotationY;
    Vector3 movedir = Vector3.zero;
    


    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);

        if (controller.isGrounded)
        {

            if (Input.GetKey(KeyCode.W))  // Move forward
            {

                if (Input.GetKey(KeyCode.LeftShift))  // Move forward RUN
                {
                    anim.SetInteger("run", 1);
                    transform.position += transform.forward * Time.deltaTime * runspeed;
                }
                else
                {
                    anim.SetInteger("run", 0);

                    anim.SetInteger("walk", 1);
                    transform.position += transform.forward * Time.deltaTime * speed;
                    if (Input.GetKeyUp(KeyCode.S))
                    {
                        anim.SetInteger("jump", 0);
                        transform.position += transform.forward * Time.deltaTime * 0;


                    }

                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("walk", 0);
                transform.position += transform.forward * Time.deltaTime * 0;
                

            }
             if (Input.GetKey(KeyCode.S))  // Move backward
            {

                    if (Input.GetKey(KeyCode.LeftShift))  // Move backward RUN
                    {
                        anim.SetInteger("run", 1);
                        transform.position -= transform.forward * Time.deltaTime * runspeed;
                    }

                    else
                    {
                        anim.SetInteger("run", 0);

                        anim.SetInteger("walk", 1);
                        transform.position -= transform.forward * Time.deltaTime * speed;

                    }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("walk", 0);
                transform.position += transform.forward * Time.deltaTime * 0;
                

            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetInteger("jump", 1);
                
                transform.position += transform.up * Time.deltaTime * speed;


            }
            else
            {
                anim.SetInteger("jump", 0);

            }
            

        }

        

        
        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
    }
}
