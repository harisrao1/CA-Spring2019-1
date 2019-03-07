using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Part2MoveScript : MonoBehaviour
{
    /*//public Camera cam;
    //public NavMeshAgent agent;
    //public GameObject getDirector;
    //private Director director;
    //CharacterController controller;
    //Animator animator;
    //private string safeFloor;
    //private float x;
    //private float y;
    //private float z;
    //public float jumpSpeed = 40;
    //private bool onoffmesh;
    private Material[] skinMaterial;
    private Color[] orignalColor;
    private bool Inrun;
    private float runC;
    private float runspeed;
    private float walkspeed;
    
    // public float stopingDistance;
    //Vector3 destination = new Vector3(0, 0, 0);
    ///Ray ray;
    //RaycastHit hit;
    
    void Start()
    {
        director = getDirector.GetComponent<Director>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Inrun = false;
        runC = 2;
        walkspeed = agent.speed;
        runspeed = agent.speed * 3;
        //Debug.Log(walkspeed + "|" + runspeed);
        //currentFloor = "anything";
        //safeFloor = "floor2";
    }

    void Update()
    {
        
        

        /*if (agent.isOnOffMeshLink)
        {
            onoffmesh = true;
            animator.SetInteger("jump", 1);
        }
        else
        {
            animator.SetInteger("jump", 0);
        }*/
      
       // Debug.Log(onoffmesh);
        /*if (Inrun)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetInteger("walk", 0);
                animator.SetInteger("run", 1);

                // Debug.Log("Velocity" + agent.velocity);
                agent.speed = runspeed;
            }
            else
            {
                animator.SetInteger("walk", 0);
                animator.SetInteger("run", 0);

            }
        }
        else
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetInteger("run", 0);
                animator.SetInteger("walk", 1);
                // Debug.Log("Velocity" + agent.velocity);
                agent.speed = walkspeed;
            }
            else
            {
                animator.SetInteger("walk", 0);
                animator.SetInteger("run", 0);
            }
        }*/
        

       /*if (Input.GetMouseButtonDown(0))
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
        }*/
        /*
        SkinnedMeshRenderer[] renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        skinMaterial = new Material[renderers.Length];
        orignalColor = new Color[renderers.Length];
        if (director.selected == agent.tag)
        {
           
               for (int i = 0; i < renderers.Length; i++)
                {
                    skinMaterial[i] = renderers[i].material;
                   
                    orignalColor[i] = skinMaterial[i].color;
                }
                
                    skinMaterial[2].color = Color.red;
                    skinMaterial[1].color = Color.red;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                runC++;
                Debug.Log(runC);
            }
            if (runC % 2 == 0)
            {

                Inrun = false;
                skinMaterial[2].color = Color.red;
                skinMaterial[1].color = Color.red;
            }
            else
            {
                Inrun = true;
                skinMaterial[2].color = Color.blue;
                skinMaterial[1].color = Color.blue;
            }

        }
        else
        {
            runC = 2;
            for (int i = 0; i < renderers.Length; i++)
            {
                skinMaterial[i] = renderers[i].material;

                orignalColor[i] = skinMaterial[i].color;
            }
            skinMaterial[2].color = Color.white;
            skinMaterial[1].color = Color.white;


        }
       
    }

    */
}
