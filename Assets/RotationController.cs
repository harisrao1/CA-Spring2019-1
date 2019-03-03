using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    //public float speed = 3;
    //public float inspeed = 3;
    //public float runspeed = 0.5f;
    public float rotationSpeed = 80;
    public float gravity = 100;
    // public float jumpspeed = 7;
    //float rotation;
   // float rotationX;
    float rotationY;
    //Vector3 movedir = Vector3.zero;
    //private Rigidbody rb;



    CharacterController controller;
    //Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        rotationY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}