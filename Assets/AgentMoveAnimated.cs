using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveAnimated : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject getDirector;
    private Director director;
    public GameObject currentFloor;
    CharacterController controller;
    Animator animator;
    //private string safeFloor;
    private GameObject safeFloor;
    private float x;
    private float y;
    private float z;
    private bool moving;
    private bool jumping;
    private GameObject floor;
    public float jumpSpeed = 40;
    private bool onoffmesh;
   // public float stopingDistance;
    Vector3 destination = new Vector3(0, 0, 0);
    Ray ray;
    RaycastHit hit;
    public float m_Damping = 0.15f;
    
    void Start()
    {
        director = getDirector.GetComponent<Director>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //currentFloor = "anything";
        moving = false;
        //safeFloor = "floor2";
        jumping = false;
    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            onoffmesh = true;
        }
        if (onoffmesh) {
            Debug.Log("hey");
            animator.SetInteger("jump", 1);
            if ((agent.transform.position.x < agent.currentOffMeshLinkData.endPos.x) )
            {
                agent.transform.Translate(Vector3.back * Time.deltaTime * jumpSpeed);
                
            }
            if ((agent.transform.position.x > agent.currentOffMeshLinkData.endPos.x))
            {
                
                agent.transform.Translate(Vector3.forward * Time.deltaTime * jumpSpeed);
               
            }
            if ((agent.transform.position.z < agent.currentOffMeshLinkData.endPos.z))
            {
                
                agent.transform.Translate(Vector3.right * Time.deltaTime * jumpSpeed);
                
            } 
            if ((agent.transform.position.z > agent.currentOffMeshLinkData.endPos.z))
            {
                
                agent.transform.Translate(Vector3.left * Time.deltaTime * jumpSpeed);
               
            }

            if (agent.transform.position.x >= agent.currentOffMeshLinkData.endPos.x - 0.2
&& agent.transform.position.x <= agent.currentOffMeshLinkData.endPos.x + 0.2
&& agent.transform.position.z >= agent.currentOffMeshLinkData.endPos.z - 0.2
&& agent.transform.position.z <= agent.currentOffMeshLinkData.endPos.z + 0.2)
            {
                
                Debug.Log("heyff");
                agent.CompleteOffMeshLink();
                onoffmesh = false;
                agent.Resume();
                

            }
            
        }
        else
        {
            animator.SetInteger("jump", 0);
        }
        Debug.Log(onoffmesh);
        
        if (agent.remainingDistance > 1.2f)
        {
            animator.SetInteger("walk", 1);
           // Debug.Log("Velocity" + agent.velocity);
        }
        else
        {
            animator.SetInteger("walk", 0);
        }
       
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform.parent.gameObject.tag == "agents" || hit.collider.transform.parent.gameObject.tag == "nazguls")
                {
                    director.selected = hit.collider.tag;
                }
                else if (director.selected == agent.tag)
                {
                    agent.SetDestination(hit.point);
                    moving = false;
                }
            }
        }
        if (director.selected == agent.tag)
        {
            if (agent.transform.parent.gameObject.tag == "nazguls")
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.yellow;
            }
        }

        else
        {
            if (agent.transform.parent.gameObject.tag == "nazguls")
            {
                GetComponent<Renderer>().material.color = Color.black;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
        }

        if (director.list.Count == 0)
        {
            director.list.Add(director.floor1);
            director.list.Add(director.floor2);
            director.list.Add(director.floor3);
            director.list.Add(director.floor4);
            director.safeFloorCount = 2;
        }
        else if (moving == false)
        {
            safeFloor = director.list[Random.Range(0, (director.list.Count - 1))];
        }

        if (agent.transform.parent.gameObject.tag != "nazguls" && !director.list.Contains(currentFloor))
        {
            Debug.Log("I want to escape!");
            Debug.Log(moving);
            if (moving == false)
            {
                float x_size = safeFloor.GetComponent<Collider>().bounds.size.x / 2;
                float z_size = safeFloor.GetComponent<Collider>().bounds.size.z / 2;
                x = Random.Range((safeFloor.transform.position.x - x_size), (safeFloor.transform.position.x + x_size));
                y = 0;
                z = Random.Range((safeFloor.transform.position.z - z_size), (safeFloor.transform.position.z + z_size));
                destination = new Vector3(x, y, z);
                agent.SetDestination(destination);
               
                moving = true;
            }
        }
        if (currentFloor == safeFloor)
        {
            moving = false;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent.tag == "FloorTriggers")
        {
            currentFloor = other.gameObject;
        }
       /* if (other.gameObject.transform.parent.tag == "jumptrigger")
        {
            Debug.Log("trig");
            animator.SetInteger("walk", 0);
            animator.SetInteger("jump", 1);
        }
        else
        {
            animator.SetInteger("jump", 0);
           // animator.SetInteger("walk", 1);
        }*/
    }

    
}
