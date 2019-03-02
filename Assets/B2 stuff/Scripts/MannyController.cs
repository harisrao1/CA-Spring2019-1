using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannyController : MonoBehaviour
{
    public float speed = 4;
    public float rotationSpeed = 80;
    public float gravity = 8;
    float rotation;
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
        if (controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))  // Move forward
            {
                anim.SetInteger("walk", 1);
                movedir = new Vector3(0, 0, 1);
                movedir = movedir * speed;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("walk", 0);
                movedir = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))  // Move backward
            {
                anim.SetInteger("walk", 1);
                movedir = new Vector3(0, 0, -1);
                movedir = movedir * speed;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("walk", 0);
                movedir = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))  // Move left
            {
                anim.SetInteger("leftwalk", 1);
                anim.SetInteger("walk", 1);
                movedir = new Vector3(-1, 0, 0);
                movedir = movedir * speed;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetInteger("walk", 0);
                movedir = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))  // Move right
            {
                anim.SetInteger("rightwalk", 1);
                
                anim.SetInteger("walk", 1);
                movedir = new Vector3(1, 0, 0);
                movedir = movedir * speed;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetInteger("walk", 0);
                anim.SetInteger("rightwalk", 0);
                movedir = new Vector3(0, 0, 0);
            }
        }

        
        movedir.y -= gravity * Time.deltaTime;
        controller.Move(movedir * Time.deltaTime);
    }
}
