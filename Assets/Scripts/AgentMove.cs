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
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        director = getDirector.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.transform.parent.gameObject.tag == "agents")
                {
                    director.selected = hit.collider.tag;
                }
                else if(hit.collider.transform.parent.gameObject.tag != "Obstacles" && director.selected == agent.tag)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
        if (director.selected == agent.tag)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }
}
