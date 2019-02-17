using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public NavMeshAgent nazgul;
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
                else if(director.selected == agent.tag)
                {
                    agent.SetDestination(hit.point);
                }else if(director.selected == "nazgul")
                {
                    director.selected = hit.collider.tag;
                }
            }
        }
        if (director.selected == agent.tag)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (director.selected == nazgul.tag)
        {
            GetComponent<Renderer>().material.color = Color.red;
           
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        

    }

  

}
