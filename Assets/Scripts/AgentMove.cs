using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject getDirector;
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
                if (hit.collider.tag == "agent1")
                {
                    director.selected = "agent1";
                }
                else if (hit.collider.tag == "agent2")
                {
                    director.selected = "agent2";
                }
                else if (hit.collider.tag == "agent3")
                {
                    director.selected = "agent3";
                }
                else if (hit.collider.tag == "agent4")
                {
                    director.selected = "agent4";
                }
                else if (hit.collider.tag == "agent5")
                {
                    director.selected = "agent5";
                }
                else if (hit.collider.tag == "agent0")
                {
                    director.selected = "agent0";
                }
                else if(director.selected == agent.tag)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

    }
}
