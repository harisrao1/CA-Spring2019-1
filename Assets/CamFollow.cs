using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float CamMoveSpeed = 120;
    public float mouseSensitivity = 2;
    public GameObject CamObj;
    public GameObject PlayerObj;
    public float clampAngle = 90;
    public float XDistance;
    public float YDistance;
    public float ZDistance;
    public float mouseX;
    public float mouseY;
    public float finalX;
    public float finalY;
    public float smoothX;
    public float smoothY;
    public float rotationX;
    public float rotationY;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotationX = rotation.x;
        rotationY = rotation.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = mouseSensitivity * Input.GetAxis("Mouse X");
        mouseY = mouseSensitivity * Input.GetAxis("Mouse Y");
        PlayerObj.transform.Rotate(0, mouseX, 0);
    }
}
