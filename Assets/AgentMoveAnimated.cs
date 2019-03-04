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
    CharacterController controller;
    Animator animator;
    //private string safeFloor;
    private float x;
    private float y;
    private float z;
    public float jumpSpeed = 40;
    private bool onoffmesh;
    private Material[] skinMaterial;
    private Color[] orignalColor;
    
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
            animator.SetInteger("jump", 1);
        }
        else
        {
            animator.SetInteger("jump", 0);
        }
        /* if (onoffmesh) {
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
         */
        Debug.Log(onoffmesh);
        
        if (agent.remainingDistance > agent.stoppingDistance)
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
        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        skinMaterial = new Material[renderers.Length];
        orignalColor = new Color[renderers.Length];
        if (director.selected == agent.tag)
        {
            if (agent.transform.parent.gameObject.tag == "nazguls")
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                // GetComponent<Renderer>().material.color = Color.yellow;
                
                for (int i = 0; i < renderers.Length; i++)
                {
                    skinMaterial[i] = renderers[i].material;
                   
                    orignalColor[i] = skinMaterial[i].color;
                }
                
                    skinMaterial[2].color = Color.red;
                    skinMaterial[1].color = Color.red;

            }
        }
        else
        {
            skinMaterial[2].color = Color.blue;
            skinMaterial[1].color = Color.blue;

        }
       
    }

    
}
