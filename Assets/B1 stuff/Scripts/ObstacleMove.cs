using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshObstacle obstacle;
    public GameObject getDirector;
    public float movespeed = 0.1f;
    private Director director;

    void Start()
    {
        director = getDirector.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.transform.parent.gameObject.tag == "Obstacles")
                {
                    director.selected = hit.collider.tag;
                }
            }
        }
        if (director.selected == obstacle.tag)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            //INSERT ARROW KEY OBSTACLE MOVEMENT BELOW
            //REFER TO AN OBSTACLE WITH "obstacle"
            //EXAMPLE: obstacle.transform.translate(...);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //transform.position = transform.position + transform.forward * movespeed;
                transform.Translate(new Vector3(0f, 0f, 10f) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0f, 0f, -10f) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(10f, 0f, 0f) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-10f, 0f, 0f) * Time.deltaTime);
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }
}
