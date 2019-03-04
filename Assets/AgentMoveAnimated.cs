﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveAnimated : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject getDirector;
    private Director director;
    CharacterController controller;
    Animator animator;
    //private string safeFloor;
    private float x;
    private float y;
    private float z;
    public float jumpSpeed = 40;
    private bool onoffmesh;
   // public float stopingDistance;
    Vector3 destination = new Vector3(0, 0, 0);
    Ray ray;
    RaycastHit hit;
    
    void Start()
    {
        director = getDirector.GetComponent<Director>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //currentFloor = "anything";
        //safeFloor = "floor2";
    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            onoffmesh = true;
        }
        if (onoffmesh) {
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

            if (
                   agent.transform.position.x >= agent.currentOffMeshLinkData.endPos.x - 0.2
                && agent.transform.position.x <= agent.currentOffMeshLinkData.endPos.x + 0.2
                && agent.transform.position.z >= agent.currentOffMeshLinkData.endPos.z - 0.2
                && agent.transform.position.z <= agent.currentOffMeshLinkData.endPos.z + 0.2
                )
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
    }

    
}
