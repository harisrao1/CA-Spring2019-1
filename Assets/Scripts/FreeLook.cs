using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 5;
    public float MouseLookSens = 5;
    public float UpDownSens = 2;

    private float X = 0;
    private float Y = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            X = X + Input.GetAxis("Mouse X") * MouseLookSens;
            Y = Y + Input.GetAxis("Mouse Y") * MouseLookSens;
            Y = Mathf.Clamp(Y, -90, 90);
        }

        transform.localRotation = Quaternion.AngleAxis(X, Vector3.up);
        transform.localRotation = transform.localRotation * Quaternion.AngleAxis(Y, Vector3.left);

        if (Input.GetKey(KeyCode.LeftShift)){
            transform.position = transform.position + transform.forward * Input.GetAxis("Vertical") * movespeed *2;
            transform.position = transform.position + transform.right * Input.GetAxis("Horizontal") * movespeed *2;

        }
        else
        {
            transform.position = transform.position + transform.forward * Input.GetAxis("Vertical") * movespeed ;
            transform.position = transform.position + transform.right * Input.GetAxis("Horizontal") * movespeed ;
        }


        if(Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + transform.up * UpDownSens;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position - transform.up * UpDownSens;
        }
       
    }
}
