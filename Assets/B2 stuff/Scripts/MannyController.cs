using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannyController : MonoBehaviour
{
    public float speed = 4;
    public float runspeed = 8;
    public float rotationSpeed = 80;
    public float gravity = 20;
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

                if (Input.GetKey(KeyCode.LeftShift))  // Move forward
                {
                    anim.SetInteger("run", 1);
                    transform.position += transform.forward * Time.deltaTime * runspeed;
                    // movedir = new Vector3(0, 0, 1);
                    // movedir = movedir * runspeed;
                }
                else
                {
                    anim.SetInteger("run", 0);

                     anim.SetInteger("walk", 1);
                    transform.position += transform.forward * Time.deltaTime * speed;
                   // movedir = new Vector3(0, 0, 1);
                   // movedir = movedir * speed;
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("walk", 0);
                transform.position += transform.forward * Time.deltaTime * 0;
                // movedir = new Vector3(0, 0, 0);

            }

        }

        

        
        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
    }
}
