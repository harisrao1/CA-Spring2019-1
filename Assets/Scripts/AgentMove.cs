using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public GameObject myTags;
    public string currentAgent;
    private AgentTags test;

    void Start()
    {
        test = myTags.GetComponent<AgentTags>();
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
                    test.selectedAgent = "agent1";
                }
                else if (hit.collider.tag == "agent2")
                {
                    test.selectedAgent = "agent2";
                }
                else if(test.selectedAgent == agent.tag)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

    }
}
